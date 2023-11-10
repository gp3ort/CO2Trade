using System.Net;
using AutoMapper;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Models.Projects;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service.IService;

namespace CO2Trade_Login_Register.Service;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IEntityUserRepository _entityUserRepo;
    private readonly IEntityProjectRepository _entityProjectRepository;
    private readonly IPurchaseRepository _purchaseRepository;
    
    private readonly IMapper _mapper;
    private APIResponse _response;


    public OperationService(IOperationRepository operationRepository, IProjectRepository projectRepository, 
        IEntityUserRepository entityUserRepository, IMapper mapper, IEntityProjectRepository entityProjectRepository,
        IPurchaseRepository purchaseRepository)
    {
        _operationRepository = operationRepository;
        _projectRepository = projectRepository;
        _entityUserRepo = entityUserRepository;
        _entityProjectRepository = entityProjectRepository;
        _purchaseRepository = purchaseRepository;
        _response = new();
        _mapper = mapper;
    }


    public async Task<APIResponse> AddToCart(ShoppingCartRequestDTO shoppingCartRequest)
    {
        try
        {
            ShoppingCart shoppingCartExist = await _operationRepository.GetAsync(x => x.IdEntityUser == shoppingCartRequest.IdEntityUser && x.Canceled == false && x.Processed == false);
            if (shoppingCartExist != null)
            {
                if (shoppingCartExist.Canceled == false && shoppingCartExist.Processed == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage.Add("You already have a cart");
                    return _response; 
                }
                
            }
            
            Project project = await _projectRepository.GetAsync(x => x.Id == shoppingCartRequest.IdProject);
            if (project.sold)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Project can not be added, because it's already sold");
                return _response; 
            }
            EntityUser entityUser = await _entityUserRepo.GetAsync(x => x.Id == shoppingCartRequest.IdEntityUser);
            ShoppingCartResponseDTO responseDto = new ShoppingCartResponseDTO();
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.IdProject = project.Id;
            shoppingCart.Project = project;
            shoppingCart.IdEntityUser = entityUser.Id;
            shoppingCart.EntityUser = entityUser;
            shoppingCart.Canceled = false;
            shoppingCart.Processed = false;
            await _operationRepository.CreateAsync(shoppingCart);

            _response.StatusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
            _response.Result = responseDto.Project = project;
            
            return _response;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add(e.Message);
            return _response;
        }
    }

    public async Task<APIResponse> CancelCart(ShoppingCartRequestDTO shoppingCartRequest)
    {
        try
        {
            ShoppingCart shoppingCartExist = await _operationRepository.GetAsync(x => x.IdEntityUser == shoppingCartRequest.IdEntityUser && x.Canceled == false && x.Processed == false);
            if (shoppingCartExist != null)
            {
                if (shoppingCartExist.Canceled == false && shoppingCartExist.Processed == false)
                {
                    Project project = await _projectRepository.GetAsync(x => x.Id == shoppingCartExist.IdProject);
                    shoppingCartExist.Project = project;
                    shoppingCartExist.Canceled = true;
                   await _operationRepository.Update(shoppingCartExist);
                   _response.StatusCode = HttpStatusCode.OK;
                   _response.IsSuccess = true;
                   _response.Result = shoppingCartExist;
                   return _response;
                }
            }
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add("Shopping Cart does not exist");
            return _response;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add(e.Message);
            return _response;
        }
    }

    public async Task<APIResponse> ProcessCart(ShoppingCartRequestDTO shoppingCartRequest)
    {
        try
        {
            ShoppingCart shoppingCartExist = await _operationRepository.GetAsync(x => x.IdEntityUser == shoppingCartRequest.IdEntityUser && x.Canceled == false && x.Processed == false);
            if (shoppingCartExist != null)
            {
                if (shoppingCartExist.Canceled == false && shoppingCartExist.Processed == false)
                {
                    Project project = await _projectRepository.GetAsync(x => x.Id == shoppingCartExist.IdProject);
                    EntityUser entityUser =
                        await _entityUserRepo.GetAsync(x => x.Id == shoppingCartRequest.IdEntityUser);
                    shoppingCartExist.Processed = true;
                    shoppingCartExist.Project = project;
                    project.sold = true;
                    await _projectRepository.Update(project);
                    await _operationRepository.Update(shoppingCartExist);
                    _operationRepository.CreateOperationProject(shoppingCartExist.Id, shoppingCartExist.IdProject,
                        shoppingCartExist.IdEntityUser);

                    Purchase purchase = new Purchase()
                    {
                        IdEntityUser = shoppingCartExist.IdEntityUser,
                        IdShoppingCart = shoppingCartExist.Id,
                        IdProject = shoppingCartExist.IdProject,
                        Total = project.Price,
                        DateTime = DateTime.Now,
                        OrderNumber = shoppingCartExist.Id
                    };
                    
                    if (entityUser.CO2Measure - project.TonsOfOxygen >= 0)
                    {
                        entityUser.CO2Measure -= project.TonsOfOxygen;
                    }
                    else
                    {
                        purchase.Revenue = Math.Abs(entityUser.CO2Measure - project.TonsOfOxygen);
                        entityUser.CO2Measure = 0;
                    }
                    await _purchaseRepository.CreateAsync(purchase);
                    await _entityUserRepo.Update(entityUser);
                    EntityProject entityProject = new EntityProject();
                    entityProject.IdProject = shoppingCartRequest.IdProject;
                    entityProject.IdEntityUser = shoppingCartRequest.IdEntityUser;
                    entityProject.Project = project;
                    entityProject.EntityUser = await _entityUserRepo.GetAsync(x => x.Id == shoppingCartRequest.IdEntityUser);
                    await _entityProjectRepository.CreateAsync(entityProject);
                    
                    
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Result = entityProject;
                    return _response;
                }
            }
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add("Shopping Cart does not exist");
            return _response;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add(e.Message);
            return _response;
        }
    }
}