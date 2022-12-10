namespace hvc.Extensions;

public class Filename
{
    public String Full { get; }
    public String Path { get; }
    public String Name { get; }
    public String Extension { get; }

    public Filename(String filename)
    {
        Full = filename.FullPath().EmptyIfNull();
        Path = System.IO.Path.GetDirectoryName(Full).EmptyIfNull();
        Name = System.IO.Path.GetFileNameWithoutExtension(Full).EmptyIfNull();
        Extension = System.IO.Path.GetExtension(Full).EmptyIfNull().Replace(".", "");
    }
}