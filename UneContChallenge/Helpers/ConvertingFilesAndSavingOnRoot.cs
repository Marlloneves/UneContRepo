using Microsoft.AspNetCore.Http.HttpResults;
using UneContChallenge.Presentation.Interfaces;

namespace UneContChallenge.Presentation.Helpers
{
    public class ConvertingFilesAndSavingOnRoot : IConvertingFilesAndSavingOnRoot
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ConvertingFilesAndSavingOnRoot(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<List<string>> ConvertFile(IFormFileCollection files)
        {
            var path = "/documentos/notafiscal/";
            var webRootPath = _hostingEnvironment.WebRootPath;
            var uniqueFileNames = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(fileName).ToLower();

                    // Verifica se o diretório existe e cria se não existir
                    if (!Directory.Exists(Path.Combine(webRootPath + path)))
                    {
                        Directory.CreateDirectory(Path.Combine(webRootPath + path));
                    }

                    // Define nome único para o arquivo
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                    var filePath = Path.Combine(webRootPath + path + uniqueFileName);

                    // Salva o arquivo no servidor
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Valida a extensão do arquivo
                    if (!ValidacaoExtensaoArquivo(fileExtension))
                    {
                        System.IO.File.Delete(filePath); // Remove o arquivo inválido
                        throw new Exception("Envie apenas arquivos com extensão '.jpg', '.jpeg', '.png', '.pdf'");
                    }

                    // Adiciona o nome único à lista
                    uniqueFileNames.Add(uniqueFileName);
                }
            }

            // Move os arquivos para o local final
            foreach (var uniqueFileName in uniqueFileNames)
            {
                var sourceFilePath = Path.Combine(webRootPath + path + uniqueFileName);
                var finalFilePath = Path.Combine(webRootPath + path + uniqueFileName);
                System.IO.File.Move(sourceFilePath, finalFilePath);
            }
            return uniqueFileNames;
        }
        private bool ValidacaoExtensaoArquivo(string fileExtension)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            return allowedExtensions.Contains(fileExtension);
        }
    }
}
