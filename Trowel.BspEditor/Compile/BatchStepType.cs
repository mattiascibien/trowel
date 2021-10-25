namespace Trowel.BspEditor.Compile
{
    public enum BatchStepType
    {
        CreateWorkingDirectory,
        ExportDocument,
        RunBuildExecutable,
        CheckIfSuccessful,
        ProcessBuildResults,
        DeleteWorkingDirectory,
        RunGame,
    }
}