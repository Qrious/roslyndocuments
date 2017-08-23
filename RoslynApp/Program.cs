using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace RoslynApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Task.Run(async () =>
      {
        var workspace = MSBuildWorkspace.Create();
        var solution = await workspace.OpenSolutionAsync("../../../ConsoleApp1.sln");
        var project = solution.Projects.Single(p => p.Name == "ConsoleApp1");
        var hasDocuments = project.HasDocuments;
        var documents = project.Documents;
        Console.WriteLine($"Has documents: {hasDocuments}");
        Console.WriteLine($"Documents count: {documents.Count()}");
        Console.WriteLine("Filepath of documents (if any):");
        foreach(var document in documents)
        {
          Console.WriteLine($"- {document.FilePath}");
        }
        Console.ReadLine();
      }).GetAwaiter().GetResult();
    }
  }
}
