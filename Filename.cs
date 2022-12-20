// MIT License
//
// Copyright (c) 2022 Kamil Ercan Turkarslan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
namespace hvc.Extensions;

/// <summary>
///    Creates an instance that represents a filename.
///
/// var filename = new Filename("C:\temp\file.txt");
/// 
/// Console.WriteLine(filename.Full);       // Outputs "C:\temp\file.txt"
/// Console.WriteLine(filename.Path);       // Outputs "C:\temp"
/// Console.WriteLine(filename.Name);       // Outputs "file"
/// Console.WriteLine(filename.Extension);  // Outputs "txt"
/// 
/// </summary>
public class Filename
{
    public Filename(String filename)
    {
        Full = filename.FullPath().EmptyIfNull();
        Path = System.IO.Path.GetDirectoryName(Full).EmptyIfNull();
        Name = System.IO.Path.GetFileNameWithoutExtension(Full).EmptyIfNull();
        Extension = System.IO.Path.GetExtension(Full).EmptyIfNull().Replace(".", "");
    }

    public String Full { get; }
    public String Path { get; }
    public String Name { get; }
    public String Extension { get; }
}