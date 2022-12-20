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
///     A one time flag that can be set only once.
///     Can be used for appending comma separated values to a string
/// </summary>
public class OneTimeFlag
{
    private Boolean _flag = true;

    /// <summary>
    ///     Returns true if the flag has not been raised yet, and false otherwise. If the flag has not been raised yet, it sets
    ///     _flag to false so that subsequent calls to this method will return false.
    /// </summary>
    /// <returns></returns>
    public Boolean IsFirstTime()
    {
        if (!_flag)
            return false;

        _flag = false;
        return true;
    }

    /// <summary>
    ///    Resets the flag to true.
    /// </summary>
    public void RaiseFlag()
    {
        _flag = true;
    }
}
