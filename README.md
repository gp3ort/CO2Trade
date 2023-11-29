# CO2Trade

La huella de carbono es un indicador crítico en la actualidad que refleja los niveles de contaminación que una empresa o individuo genera hacia el medio ambiente. Esta huella
afecta el cambio climático y la salud del planeta en general. En respuesta a esta problemática, hemos desarrollado un proyecto significativo: la creación de una plataforma de trading monetizado de proyectos medioambientales. Esta plataforma tipo marketplace permitirá a empresas e individuos compensar su huella de carbono a través de inversiones en proyectos medioambientales

Esta API proporciona servicios relacionados con autenticación, generación de certificados, operaciones de carrito de compras, pagos con Mercado Pago y gestión de proyectos.

# Clase APIResponse

Proporciona una estructura de respuesta estándar para todas las operaciones de la API.

Propiedades:

- StatusCode: Código de estado HTTP.
- IsSuccess: Indica si la operación fue exitosa.
- ErrorMessage: Lista de mensajes de error detallados.
- Result: Resultado de la operación.

Constructor:

Inicializa una nueva instancia de la clase y la lista de mensajes de error.

# Controladores:

### CertificateController

- Gestiona la generación y obtención de certificados.

.- Rutas:

- POST /api/Certificate/buildCertificate: Construye un nuevo certificado.
- POST /api/Certificate/getCertificate: Obtiene un certificado existente.

Dependencias:

- ICertificateService: Interfaz utilizada para realizar operaciones con certificados.

Constructor:

- Recibe un servicio de certificados (ICertificateService) como dependencia.

Método Adicional:

- BuildBadRequestApiResponse: Construye una respuesta de error estándar.

<img width="1256" alt="Captura de Pantalla 2023-11-29 a la(s) 09 28 15" src="https://github.com/gp3ort/CO2Trade/assets/101581586/f190cd9e-778e-44af-a8d7-bf5705b560f7">


### ProjectController

Gestiona operaciones relacionadas con proyectos.

Rutas:

- POST /api/Project/create: Crea un nuevo proyecto.
- GET /api/Project/getAllProjects: Obtiene todos los proyectos.
- GET /api/Project/getAvailableProjects: Obtiene proyectos disponibles.
- GET /api/Project/getProject: Obtiene un proyecto específico.
- DELETE /api/Project/removeProject: Elimina un proyecto.
- PUT /api/Project/updateProject: Actualiza un proyecto.
- POST /api/Project/filterProjects: Filtra proyectos.

Dependencias:

- IProjectService: Interfaz utilizada para realizar operaciones con proyectos.

Constructor:

- Recibe un servicio de proyectos (IProjectService) como dependencia.

<img width="1255" alt="Captura de Pantalla 2023-11-29 a la(s) 08 56 51" src="https://github.com/gp3ort/CO2Trade/assets/101581586/3d7d332a-e541-4e60-8c43-6445a65a37df">


### EntityUsersController

Gestiona operaciones relacionadas con usuarios de la entidad.

Rutas:

- POST /api/UsersAuth/login: Inicia sesión de usuario.
- POST /api/UsersAuth/register: Registra un nuevo usuario.
- POST /api/UsersAuth/addCO2: Agrega medidas de CO2.
- POST /api/UsersAuth/myProjects: Obtiene proyectos asociados a un usuario.
- GET /api/UsersAuth/user/{id}: Obtiene información de un usuario.
- POST /api/UsersAuth/changePassword: Cambia la contraseña de un usuario.

Dependencias:

- IEntityUserService: Interfaz utilizada para realizar operaciones con usuarios de entidad.

Constructor:

Recibe un servicio de usuarios de entidad (IEntityUserService) como dependencia.

<img width="1255" alt="Captura de Pantalla 2023-11-29 a la(s) 09 42 43" src="https://github.com/gp3ort/CO2Trade/assets/101581586/701784c0-e1e0-4c2f-bcf3-8fb103004b59">


### MercadoPagoController

Gestiona operaciones de pago utilizando Mercado Pago.

Rutas:

- POST /api/MercadoPago/pay: Procesa un pago con Mercado Pago.

Dependencias:

- IMercadoPagoService: Interfaz utilizada para realizar operaciones con Mercado Pago.
- IOperationService: Interfaz utilizada para realizar operaciones generales.

Constructor:

Recibe servicios de Mercado Pago (IMercadoPagoService) y operaciones (IOperationService) como dependencias.


<img width="1257" alt="Captura de Pantalla 2023-11-29 a la(s) 09 24 16" src="https://github.com/gp3ort/CO2Trade/assets/101581586/91cf8e97-2742-4645-b761-cbfafdf756ef">

### OperationController

Gestiona operaciones relacionadas con carritos de compras.

Rutas:

- POST /api/Operations/addToCart: Agrega elementos al carrito de compras.
- POST /api/Operations/cancelCart: Cancela el contenido del carrito de compras.
- POST /api/Operations/processCart: Procesa el carrito de compras.

Dependencias:

- IOperationService: Interfaz utilizada para realizar operaciones con carritos de compras.

Constructor:

- Recibe un servicio de operaciones (IOperationService) como dependencia.

<img width="1251" alt="Captura de Pantalla 2023-11-29 a la(s) 09 20 27" src="https://github.com/gp3ort/CO2Trade/assets/101581586/461e3518-4524-4d82-9142-ba27aa6093a9">

