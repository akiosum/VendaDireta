using System.Reflection;

namespace VendaDireta.Aplication;

public static class ApplicationAssembly
{
    public static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
}