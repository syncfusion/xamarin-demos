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

using Foundation;
using UIKit;

namespace SampleBrowser
{
    internal class ScheduleLocalViewModel
    {
        internal ScheduleLocalViewModel()
        {

        }

        internal List<string> EnglishCollection;
        internal void SetEnglishCollectionSubjects()
        {
            EnglishCollection = new List<string>();
            EnglishCollection.Add("GoToMeeting");
            EnglishCollection.Add("Business Meeting");
            EnglishCollection.Add("Conference");
            EnglishCollection.Add("Project Status Discussion");
            EnglishCollection.Add("Auditing");
            EnglishCollection.Add("Client Meeting");
            EnglishCollection.Add("Generate Report");
            EnglishCollection.Add("Target Meeting");
            EnglishCollection.Add("General Meeting");
            EnglishCollection.Add("Pay House Rent");
            EnglishCollection.Add("Car Service");
            EnglishCollection.Add("Medical Check Up");
            EnglishCollection.Add("Wedding Anniversary");
            EnglishCollection.Add("Sam's Birthday");
            EnglishCollection.Add("Jenny's Birthday");
            EnglishCollection.Add("Master Checkup");
            EnglishCollection.Add("Hospital");
            EnglishCollection.Add("Phone Bill Payment");
            EnglishCollection.Add("Project Plan");
            EnglishCollection.Add("Auditing");
            EnglishCollection.Add("Client Meeting");
            EnglishCollection.Add("Generate Report");
            EnglishCollection.Add("Target Meeting");
            EnglishCollection.Add("General Meeting");
            EnglishCollection.Add("Play Golf");
            EnglishCollection.Add("Car Service");
            EnglishCollection.Add("Medical Check Up");
            EnglishCollection.Add("Mary's Birthday");
            EnglishCollection.Add("John's Birthday");
            EnglishCollection.Add("Micheal's Birthday");
        }

        internal List<string> FrenchCollection;
        internal void SetFrenchCollectionSubjects()
        {
            FrenchCollection = new List<string>();
            FrenchCollection.Add("aller ‡ la rÈunion");
            FrenchCollection.Add("Un rendez-vous d'affaire");
            FrenchCollection.Add("ConfÈrence");
            FrenchCollection.Add("Discussion Projet de Statut");
            FrenchCollection.Add("audit");
            FrenchCollection.Add("RÈunion du client");
            FrenchCollection.Add("gÈnÈrer un rapport");
            FrenchCollection.Add("RÈunion cible");
            FrenchCollection.Add("AssemblÈe gÈnÈrale");
            FrenchCollection.Add("Pay Maison Louer");
            FrenchCollection.Add("Service automobile");
            FrenchCollection.Add("Visite mÈdicale");
            FrenchCollection.Add("Anniversaire de mariage");
            FrenchCollection.Add("Anniversaire de Sam");
            FrenchCollection.Add("Anniversaire de Jenny");
            FrenchCollection.Add("Checkup Master");
            FrenchCollection.Add("HÙpital");
            FrenchCollection.Add("TÈlÈphone paiement de factures");
            FrenchCollection.Add("Plan de projet");
            FrenchCollection.Add("audit");
            FrenchCollection.Add("RÈunion du client");
            FrenchCollection.Add("gÈnÈrer un rapport");
            FrenchCollection.Add("RÈunion cible");
            FrenchCollection.Add("AssemblÈe gÈnÈrale");
            FrenchCollection.Add("Jouer au golf");
            FrenchCollection.Add("Service automobile");
            FrenchCollection.Add("Visite mÈdicale");
            FrenchCollection.Add("Anniversaire de Marie");
            FrenchCollection.Add("Anniversaire de John");
            FrenchCollection.Add("Anniversaire de Micheal");
        }

        internal List<string> SpanishCollection;
        internal void SetSpanishCollectionSubjects()
        {
            SpanishCollection = new List<string>();
            SpanishCollection.Add("Ir a la reuniÛn");
            SpanishCollection.Add("ReuniÛn de negocios");
            SpanishCollection.Add("Conferencia");
            SpanishCollection.Add("SituaciÛn del proyecto DiscusiÛn");
            SpanishCollection.Add("AuditorÌa");
            SpanishCollection.Add("ReuniÛn Cliente");
            SpanishCollection.Add("Generar informe");
            SpanishCollection.Add("ReuniÛn Target");
            SpanishCollection.Add("ReuniÛn general");
            SpanishCollection.Add("Pago Casa Alquilar");
            SpanishCollection.Add("Servicio de auto");
            SpanishCollection.Add("RevisiÛn mÈdica");
            SpanishCollection.Add("Aniversario de bodas");
            SpanishCollection.Add("CumpleaÒos de Sam");
            SpanishCollection.Add("El cumpleaÒos de Jenny");
            SpanishCollection.Add("Chequeo Maestro");
            SpanishCollection.Add("el Hospital");
            SpanishCollection.Add("TelÈfono pago de facturas");
            SpanishCollection.Add("Plan de proyecto");
            SpanishCollection.Add("AuditorÌa");
            SpanishCollection.Add("ReuniÛn Cliente");
            SpanishCollection.Add("Generar informe");
            SpanishCollection.Add("ReuniÛn Target");
            SpanishCollection.Add("ReuniÛn general");
            SpanishCollection.Add("Jugar golf");
            SpanishCollection.Add("Servicio de auto");
            SpanishCollection.Add("RevisiÛn mÈdica");
            SpanishCollection.Add("CumpleaÒos de MarÌa");
            SpanishCollection.Add("John CumpleaÒos");
            SpanishCollection.Add("El cumpleaÒos de Micheal");
        }

        internal List<string> ChineseCollection;
        internal void SetChineseCollectionSubjects()
        {
            ChineseCollection = new List<string>();
            ChineseCollection.Add("进入会议");
            ChineseCollection.Add("商务会议");
            ChineseCollection.Add("会议");
            ChineseCollection.Add("项目状态讨论");
            ChineseCollection.Add("审计");
            ChineseCollection.Add("客户会议");
            ChineseCollection.Add("生成报告");
            ChineseCollection.Add("目标会议");
            ChineseCollection.Add("大会");
            ChineseCollection.Add("支付房租");
            ChineseCollection.Add("汽车服务");
            ChineseCollection.Add("体格检查");
            ChineseCollection.Add("结婚纪念日");
            ChineseCollection.Add("萨姆的生日");
            ChineseCollection.Add("珍妮的生日");
            ChineseCollection.Add("主诊");
            ChineseCollection.Add("医院");
            ChineseCollection.Add("电话缴费");
            ChineseCollection.Add("项目计划");
            ChineseCollection.Add("审计");
            ChineseCollection.Add("客户会议");
            ChineseCollection.Add("生成报告");
            ChineseCollection.Add("目标会议");
            ChineseCollection.Add("大会");
            ChineseCollection.Add("打高尔夫球");
            ChineseCollection.Add("汽车服务");
            ChineseCollection.Add("体格检查");
            ChineseCollection.Add("玛丽的生日");
            ChineseCollection.Add("约翰的生日");
            ChineseCollection.Add("迈克尔的生日");
        }

        // adding colors collection
        internal List<UIColor> ColorCollection;
        internal void SetColors()
        {
            ColorCollection = new List<UIColor>();
            ColorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
            ColorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            ColorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
            ColorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            ColorCollection.Add(UIColor.FromRGB(0xF0, 0x96, 0x09));
            ColorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
            ColorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
            ColorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            ColorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
            ColorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            ColorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
            ColorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
            ColorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
            ColorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
            ColorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
        }
    }
}