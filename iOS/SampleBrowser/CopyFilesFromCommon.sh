#!/bin/sh
# Define directories.
ProjectPath=$(PWD)


ESPath="${ProjectPath%/*}"

mkdir $ProjectPath/Samples/DocIO/Templates
mkdir $ProjectPath/Samples/PDFViewer/Assets
mkdir $ProjectPath/Samples/PDF/Assets
mkdir $ProjectPath/Samples/Presentation/Templates
mkdir $ProjectPath/Samples/XlsIO/Template


cp $ESPath/essentialstudio-common/Data/DocIO/BkmkDocumentPart_Template.doc $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Data/DocIO/Bookmark_Template.doc $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Data/DocIO/Excel_Template.xlsx $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Data/DocIO/Products.xml $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Data/DocIO/Employees.xml $ProjectPath/Samples/DocIO/Templates/
cp "$ESPath/essentialstudio-common/Data/DocIO/Letter Formatting.docx" $ProjectPath/Samples/DocIO/Templates/
cp "$ESPath/essentialstudio-common/Data/DocIO/ContentControlTemplate.docx" $ProjectPath/Samples/DocIO/Templates/
cp "$ESPath/essentialstudio-common/Data/DocIO/Doc to HTML.doc" $ProjectPath/Samples/DocIO/Templates/
cp "$ESPath/essentialstudio-common/Data/DocIO/WordtoPDF.docx" $ProjectPath/Samples/DocIO/Templates/
cp -R "$ESPath/essentialstudio-common/Data/DocIO/Doc to HTML.doc" $ProjectPath/Samples/DocIO/Templates/WordtoHTML.doc
cp "$ESPath/essentialstudio-common/Data/DocIO/Template.doc" $ProjectPath/Samples/DocIO/Templates/
cp "$ESPath/essentialstudio-common/Data/DocIO/EmployeesReportDemo.doc" $ProjectPath/Samples/DocIO/Templates/
cp "$ESPath/essentialstudio-common/Data/DocIO/Template_Letter.doc" $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Images/DocIO/AdventureCycle.jpg $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Images/DocIO/Mountain-200.jpg $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Images/DocIO/Mountain-300.jpg $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Images/DocIO/Northwind.png $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Images/DocIO/Road-550-W.jpg $ProjectPath/Samples/DocIO/Templates/
cp $ESPath/essentialstudio-common/Images/DocIO/SampleImage.png $ProjectPath/Samples/DocIO/Templates/

cp "$ESPath/essentialstudio-common/Data/PDF/GIS Succinctly.pdf" $ProjectPath/Samples/PDFViewer/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/F# Succinctly.pdf" $ProjectPath/Samples/PDFViewer/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/HTTP Succinctly.pdf" $ProjectPath/Samples/PDFViewer/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/Xamarin Forms Succinctly.pdf" $ProjectPath/Samples/PDFViewer/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/FormFillingDocument.pdf" $ProjectPath/Samples/PDFViewer/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/Encrypted Document.pdf" $ProjectPath/Samples/PDFViewer/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/JavaScript Succinctly.pdf" $ProjectPath/Samples/PDFViewer/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/Product Catalog.pdf" $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/SalesOrderDetail.pdf $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/Products.xml $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/Report.xml $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/InvoiceProductList.xml $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Images/PDF/Xamarin_bannerEdit.jpg $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Images/PDF/Xamarin_JPEG.jpg $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Images/PDF/Xamarin_PNG.png $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/PDF.pfx $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/SignedDocument.pdf $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/arial.ttf $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/arabic.txt $ProjectPath/Samples/PDF/Assets/
cp $ESPath/essentialstudio-common/Data/PDF/NotoSerif-Black.otf $ProjectPath/Samples/PDF/Assets/
cp "$ESPath/essentialstudio-common/Data/PDF/JavaScript Succinctly.pdf" $ProjectPath/Samples/PDF/Assets/

cp $ESPath/essentialstudio-common/Data/Presentation/HelloWorld.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/Images.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/NewCharts.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/Slides.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Images/Presentation/tablet.jpg $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/Products.xml $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/TableData.xml $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/SlideTableData.xml $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/ShapeWithAnimation.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/Animation.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/Transition.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/Template.pptx $ProjectPath/Samples/Presentation/Templates/
cp $ESPath/essentialstudio-common/Data/Presentation/HeaderFooter.pptx $ProjectPath/Samples/Presentation/Templates/

cp $ESPath/essentialstudio-common/Data/XlsIO/FilterData.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/IconFilterData.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/FilterData_Color.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/ReplaceOptions.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/AdvancedFilterData.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/ChartData.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/CLRObjects.xml $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/customers.xml $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/ExcelToPDF.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/ExportSales.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/ExportData.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/ExportData.xml $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/ExpenseReport.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/NorthwindTemplate.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/InvoiceTemplate.xlsx $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/bahnschrift.ttf $ProjectPath/Samples/XlsIO/Template/
cp $ESPath/essentialstudio-common/Data/XlsIO/georgiab.ttf $ProjectPath/Samples/XlsIO/Template/

