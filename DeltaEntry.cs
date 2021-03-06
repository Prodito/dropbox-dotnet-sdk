﻿/*
 * Copyright (c) 2013 Guido Pola <prodito@live.com>.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.Text;
using MiniJSON;

namespace Dropbox
{
    public class DeltaEntry
    {
        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }
        
        /// <summary>
        /// Indicates that there is a file/folder at the given path. You should add the entry to your local state.
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        public FileEntry FileEntry { get; set; }

        /// <summary>
        /// DeltaEntry default constructor.
        /// </summary>
        public DeltaEntry()
        {
            FileEntry = FileEntry.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public DeltaEntry(List<Object> json)
        {
            Path = (string)json[0];
            FileEntry = new FileEntry((JsonDictionary)json[1]);
        }
    }
}
