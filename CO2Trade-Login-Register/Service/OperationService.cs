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
    
    private readonly IMapper _mapper;
    private APIResponse _response;


    public OperationService(IOperationRepository operationRepository, IProjectRepository projectRepository, IEntityUserRepository entityUserRepository, IMapper mapper)
    {
        _operationRepository = operationRepository;
        _projectRepository = projectRepository;
        _entityUserRepo = entityUserRepository;
        _response = new();
        _mapper = mapper;
    }


    public async Task<APIResponse> AddToCart(ShoppingCartRequestDTO shoppingCartRequest)
    {
        try
        {
            ShoppingCart shoppingCartExist = await _operationRepository.GetAsync(x => x.IdEntityUser == shoppingCartRequest.IdEntityUser);
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
            EntityUser entityUser = await _entityUserRepo.GetAsync(x => x.Id == shoppingCartRequest.IdEntityUser);
            ShoppingCartResponseDTO responseDto = new ShoppingCartResponseDTO();
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.IdProject = project.Id;
            shoppingCart.Project = project;
            shoppingCart.IdEntityUser = entityUser.Id;
            shoppingCart.EntityUser = entityUser;
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
            ShoppingCart shoppingCartExist = await _operationRepository.GetAsync(x => x.IdEntityUser == shoppingCartRequest.IdEntityUser);
            if (shoppingCartExist.Canceled != null)
            {
                if (shoppingCartExist.Canceled == false)
                {
                    shoppingCartExist.Canceled = true;
                   await _operationRepository.Update(shoppingCartExist);
                   _response.StatusCode = HttpStatusCode.OK;
                   _response.IsSuccess = true;
                   _response.Result = shoppingCartExist.Project;
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
            ShoppingCart shoppingCartExist = await _operationRepository.GetAsync(x => x.IdEntityUser == shoppingCartRequest.IdEntityUser);
            if (shoppingCartExist.Canceled != null)
            {
                if (shoppingCartExist.Canceled == false)
                {
                    shoppingCartExist.Processed = true;
                    await _operationRepository.Update(shoppingCartExist);
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Result = shoppingCartExist.Project;
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