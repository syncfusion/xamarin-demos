#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser.SfPdfViewer
{
    public static class DocumentData
    {
        public static IList<Document> DocumentList { get; private set; }

        static DocumentData()
        {
            DocumentList = new List<Document>();
            DocumentList.Add(new Document("F# Succinctly"));
            DocumentList.Add(new Document("GIS Succinctly"));
            DocumentList.Add(new Document("HTTP Succinctly"));
            DocumentList.Add(new Document("JavaScript Succinctly"));
        }
    }
}
