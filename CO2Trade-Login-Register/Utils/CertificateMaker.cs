namespace CO2Trade_Login_Register.Utils;

public class CertificateMaker
{
    public static string BuildCertificate(string entityName, string projectName, decimal projectCO2)
    {
        DateTime actualDate = DateTime.Now;
        string date = actualDate.ToString("M/d/yyyy");
        string src = "Utils/logo.jpg";
        string html = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Certificado de Reducción de Emisiones de CO2</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            text-align: center;
        }}
        .certificate {{
            border: 3px solid #0073e6;
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f9f9f9;
        }}
        .logo {{
            width: 250px;
            height: auto;
        }}
        .company-name {{
            font-size: 28px;
            font-weight: bold;
            margin: 20px 0;
        }}
        .details {{
            font-size: 20px;
            margin-bottom: 20px;
        }}
        .project-name {{
            font-size: 24px;
            font-weight: bold;
            margin-top: 20px;
        }}
        .signature {{
            margin-top: 40px;
        }}
        .commitment-text {{
            font-size: 18px;
            margin-top: 20px;
            text-align: left;
        }}
    </style>
</head>
<body>
    <div class=""certificate"">
        <img src=""{src}"" alt=""GP3 Logo"" class=""logo"">
        <h1 class=""company-name"">GP3 ORT S.A.</h1>
        <p class=""details"">Certifica que la empresa {entityName.ToUpper()} ha reducido con éxito sus emisiones de CO2 en un total de {projectCO2}.</p>
        <p class=""details"">Fecha de Certificación: {date}</p>
        <p class=""project-name"">Nombre del Proyecto: {projectName.ToUpper()}</p>
        <div class=""commitment-text"">
            <p>En GP3 ORT, estamos comprometidos con la protección del medio ambiente y la sostenibilidad. Esta certificación representa un hito en nuestro esfuerzo por reducir las emisiones de CO2 y minimizar el impacto en el cambio climático.</p>
            <p>Continuaremos trabajando incansablemente para mantener y mejorar los estándares ambientales, y esperamos seguir siendo un ejemplo de liderazgo en la reducción de emisiones y la responsabilidad corporativa.</p>
        </div>
        <div class=""signature"">
            <p>Todos los miembros del Grupo 3, Alumnos ORT Argentina</p>
        </div>
    </div>
</body>
</html>";
        return html;
    }
}