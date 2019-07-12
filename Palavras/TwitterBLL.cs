using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using MinhaBibli;

namespace Palavras
{
    class TwitterBLL
    {
        public static void conectar()
        {
            Twitter.autenticar();
            Auth.SetUserCredentials(Twitter.getConsumerKey(), Twitter.getConsumerSecret(), Twitter.getAccessToken(), Twitter.getAccessSecret());
            if (Timeline.GetUserTimeline("neymarjr", 5) == null)
                Erro.setErro("Falha ao conectar a API do Twitter");
        }

        public static void validaDados()
        {
            Erro.setErro(false);
            if(Twitter.getUser().Equals(""))
            {
                Erro.setErro("O campo usuario é obrigatorio");
                return;
            }
            if (Twitter.getQtd().Equals(""))
            {
                Erro.setErro("O campo quantidade de tweets é obrigatorio");
                return;
            }
            try
            {
                int.Parse(Twitter.getQtd());
            }
            catch
            {
                Erro.setErro("O campo Quantidade de Tweets deve ser numerico");
                return;
            }
            if(int.Parse(Twitter.getQtd()) <= 0)
            {
                Erro.setErro("O campo Quantidade de Tweets deve ser maior que 0");
                return;
            }
            if(Twitter.getTweets() == null)
            {
                Erro.setErro("Twitter Inexistente");
                return;
            }
        }
    }
}
