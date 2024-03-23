using System.Reflection;

namespace VendaDireta.Domain;

public static class DomainAssembly
{
    public static Assembly Assembly => typeof(DomainAssembly).Assembly;
}