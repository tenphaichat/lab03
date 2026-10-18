using System;

namespace Lab03_OOPAdvanced
{
    public interface IValidatable
    {
        bool IsValid(out string message);
    }

    public interface IPrintable
    {
        string ToDisplayText();
    }

    public interface IExportable
    {
        string ExportToCsv();
        string ExportToJson();
    }
}
