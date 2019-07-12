using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaBibli;
using Tweetinvi;

namespace Palavras
{
    class Twitter
    {
        private static string consumerKey;
        private static string consumerSecret;
        private static string userAccessToken;
        private static string userAccessSecret;
        private static string user;
        private static string qtd;
        private static string palavras = "";
        private static string[] palavraslist;
        private static IEnumerable<Tweetinvi.Models.ITweet> tweets;

        public static void autenticar()
        {
            consumerKey = "r6e9NYaE3iEfjkTXLjLZk5Hlv";
            consumerSecret = "Yfa2qLMEbp89gfS3zt7RUITnG9hZkozcN61eq7Wiq25eGP2R6B";
            userAccessToken = "755062633884188672-qBZyVuOyMM7KOwbHtLBOhqGZgsoVQ84";
            userAccessSecret = "cWn8F8xYI9ecmyLqiAy4VMdhjMBi13ZV3A8KeQz3hrCmD";
        }

        public static void setUser(string _user) { user = _user; }
        public static void setQtd(string _qtd) { qtd = _qtd; }
        public static string getUser() { return user; }
        public static string getQtd() { return qtd; }
        public static string getConsumerKey() { return consumerKey; }
        public static string getConsumerSecret() { return consumerSecret; }
        public static string getAccessToken() { return userAccessToken; }
        public static string getAccessSecret() { return userAccessSecret; }
        public static IEnumerable<Tweetinvi.Models.ITweet> getTweets()
        {
            tweets = Timeline.GetUserTimeline(getUser(), int.Parse(getQtd()));
            return tweets;
        }
        public static void clearPalavras() { palavras = ""; }
        public static void setPalavras(string _palavra) { palavras += _palavra; }
        public static void setPalavrasList() { palavraslist = palavras.Split('?', '!', ' ', ';', ','); }
        public static string[] getPalavraList() { return palavraslist; }
    }
}
