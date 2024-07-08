namespace UneContChallenge.Presentation.Interfaces
{
    public interface IConvertingFilesAndSavingOnRoot
    {
        Task<List<string>> ConvertFile(IFormFileCollection file);
    }
}
