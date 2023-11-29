# CO2Trade
CO2Trade for BDT GLobal

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

### MercadoPagoController

Gestiona operaciones de pago utilizando Mercado Pago.

Rutas:

- POST /api/MercadoPago/pay: Procesa un pago con Mercado Pago.

Dependencias:

- IMercadoPagoService: Interfaz utilizada para realizar operaciones con Mercado Pago.
- IOperationService: Interfaz utilizada para realizar operaciones generales.

Constructor:

Recibe servicios de Mercado Pago (IMercadoPagoService) y operaciones (IOperationService) como dependencias.

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
