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
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using OAuth;

namespace Dropbox
{
    /// <summary>
    /// 
    /// </summary>
    public class Session : OAuthConsumer
    {
        /// <summary>
        /// 
        /// </summary>
        private const string kApiServer = "api.dropbox.com";

        /// <summary>
        /// 
        /// </summary>
        private const string kContentServer = "api-content.dropbox.com";

        /// <summary>
        /// 
        /// </summary>
        private const string kWebServer = "www.dropbox.com";

        /// <summary>
        /// 
        /// </summary>
        private const int kApiVersion = 1;

        /// <summary>
        /// 
        /// </summary>
        public readonly AccessType AppAccess;

        /// <summary>
        /// 
        /// </summary>
        public string AccessType { get { return _AccessType(); } }

        /// <summary>
        /// 
        /// </summary>
        public CultureInfo Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApplicationKey"></param>
        /// <param name="ApplicationSecret"></param>
        /// <param name="Access"></param>
        public Session(string ApplicationKey, string ApplicationSecret, AccessType Access)
            : base(ApplicationKey, ApplicationSecret)
        {
            Locale = new CultureInfo("en", false);
            AppAccess = Access;

            //
            //
            //
            base.RequestTokenUrl = "https://api.dropbox.com/1/oauth/request_token";
            base.AuthorizationUrlBase = "https://www.dropbox.com/1/oauth/authorize";
            base.AccessTokenUrl = "https://api.dropbox.com/1/oauth/access_token";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public override object Request(RequestMethod method, RequestType type, string url, 
            List<QueryParameter> parameters, byte[] data)
        {
            try
            {
                return base.Request(method, type, url, parameters, data);
            }
            catch (WebException e)
            {
                throw new DropboxException(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Request(RequestMethod method, RequestType type, string url, List<QueryParameter> parameters)
        {
            return Request(method, type, url, parameters, null);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string FormatAPIServerUrl(string path)
        {
            return String.Format("https://{0}/{1}{2}", kApiServer, kApiVersion, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string FormatContentUrl(string path)
        {
            return String.Format("https://{0}/{1}{2}", kContentServer, kApiServer, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string _AccessType()
        {
            return AppAccess == Dropbox.AccessType.DropboxFolder ? 
                "dropbox" : "sandbox";
        }
    }
}
