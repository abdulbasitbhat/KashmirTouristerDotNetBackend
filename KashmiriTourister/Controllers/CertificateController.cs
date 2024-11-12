using KashmiriTourister.Data;
using KashmiriTourister.Models;
using KashmiriTourister.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KashmiriTourister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CertificateController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("certificate/upload")]
        public IActionResult uploadCertificate(AddCertificateDTO addCertificateDTO)
        {
            var CertificateEntity = new Certificate()
            {
                certificate = addCertificateDTO.certificate
            };

            dbContext.Certificate.Add(CertificateEntity);
            dbContext.SaveChanges();
            return Ok(CertificateEntity);
        }

        [HttpGet]
        [Route("certificate/{id:guid}")]
        public IActionResult viewCertificate(Guid id)
        {
            var certificate = dbContext.Certificate.Find(id);
            if(certificate is null)
            {
                return NotFound();
            }
            //return Ok(certificate.certificate);
            var base64String = certificate.certificate; // Ensure this is the correct property name

            if (string.IsNullOrEmpty(base64String))
            {
                return BadRequest("No image data found.");
            }
            const string base64Prefix = "data:image/jpeg;base64,";
            if (base64String.StartsWith(base64Prefix))
            {
                base64String = base64String.Substring(base64Prefix.Length);
            }

            byte[] imageData;
            try
            {
                // Convert the Base64 string to a byte array
                imageData = Convert.FromBase64String(base64String);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid Base64 string.");
            }

            return File(imageData, "image/png");
        }
    }
}
