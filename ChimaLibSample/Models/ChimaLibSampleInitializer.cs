using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChimaLibSample.Models
{
    public class ChimaLibSampleInitializer : DropCreateDatabaseAlways<ChimaLibSampleContext>
    {
        protected override void Seed(ChimaLibSampleContext context) {
            var articles = new List<Article>() {
                new Article() {
                    Url = "http://www.buildinsider.net/web/jquerymobileref",
                    Title = "jQuery Mobile逆引きリファレンス",
                    Description = "jQuery Mobileの基本機能を目的別リファレンスの形式でまとめます。",
                    Viewcount = 36452,
                    Published = DateTime.Parse("2014-01-09"),
                    Released = true
                },
                new Article(){
                    Url = "http://codezine.jp/article/corner/518",
                    Title = "Bootstrapでレスポンシブでリッチなサイトを構築",
                    Description = "ASP.NET MVC5のひな形ページで使用されているBootstrapというフレームワークについて紹介します。",
                    Viewcount = 9312,
                    Published = DateTime.Parse("2014-05-22"),
                    Released = true
                },
                new Article() {
                    Url = "http://codezine.jp/article/corner/511",
                    Title = "ASP.NET Identity入門",
                    Description = "新しい認証、資格管理システムである「ASP.NET Identity」について、どのように使うのか、どんな仕組みで動いているのかを紹介していきます。",
                    Viewcount = 8046,
                    Published = DateTime.Parse("2014-04-25"),
                    Released = true
                },
                new Article(){
                    Url = "http://codezine.jp/article/corner/513",
                    Title = "Amazon Web Servicesによるクラウド超入門",
                    Description = "Amazon Web Servicesを使ってクラウドシステム上に簡単なWebシステムを構築していきます。",
                    Viewcount = 25687,
                    Published = DateTime.Parse("2014-04-25"),
                    Released = true
                },
                new Article(){
                    Url = "http://www.buildinsider.net/web/jqueryuiref",
                    Title = "jQuery UI逆引きリファレンス",
                    Description = "jQuery UIの基本機能を目的別リファレンスの形式でまとめます。",
                    Viewcount = 56710,
                    Published = DateTime.Parse("2013-07-11"),
                    Released = true
                },
                new Article(){
                    Url = "http://www.wings.msn.to/azure",
                    Title = "Azure新機能TIPS",
                    Description = "Microsoft Azureの新機能についてTIPS形式で、使い方などを解説します。",
                    Viewcount = 13469,
                    Published = DateTime.Parse("2014-04-25"),
                    Released = true
                },
            };

            articles.ForEach(obj => context.Articles.Add(obj));
            context.SaveChanges();
        }
    }
}