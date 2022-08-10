using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Cadastro;
using Clinica.Site.Negocio.Estrutura;

namespace Clinica.Site.Comum
{
    public class Smtp
	{
		private EmailsRepositorio _emails = new EmailsRepositorio();
		private ContaSmtpRepositorio _conta = new ContaSmtpRepositorio();

		private IEnumerable<Emails> ObterEmails()
		{
			return _emails.Obter();
		}

		private ContaSmtp ObterConta()
		{
			return _conta.Obter();
		}

		public bool EnviarEmail(string modulo, string nome, string email, string assunto, string mensagem)
		{
			ContaSmtp listConta = ObterConta();
			IEnumerable<Emails> listEmails = ObterEmails();

            //Mail Messagem From tem que apresentar um email válido.
            //Como em alguns formulário o campo email não é obrigado, tenho que colocar um valor para o From (message.From = new MailAddress(email) caso o campo não tenha sido preenchido;
            //string sEmailFrom = !String.IsNullOrEmpty(listConta.EmailFrom) ? listConta.EmailFrom : email;
            string sEmailFrom = email;

            string sEmail = email;
						
			try
			{
				foreach (var item in listEmails)
				{
					using (var smtp = new SmtpClient())
					{
						var message = new MailMessage();
                        //message.To.Add(new MailAddress(item.Endereco)); 
                        message.To.Add(new MailAddress("clinicamedicapucmg@gmail.com"));

                        message.From = new MailAddress(sEmailFrom);
						message.Subject = assunto;
						message.Body = MontaMensagem(modulo, nome, sEmail, assunto, mensagem);
						message.IsBodyHtml = true;
						var credential = new NetworkCredential
						{
							UserName = listConta.Endereco,
							Password = listConta.Senha
						};
						smtp.Credentials = credential;
						smtp.Host = listConta.Servidor;
						smtp.Port = listConta.Porta;
						smtp.EnableSsl = listConta.Seguranca;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);
					}
				}
			}

			catch(Exception e) {
                string x = e.ToString();
                return false;
			}

			return true;
		}

		private string MontaMensagem(string modulo, string nome, string email, string assunto, string mensagem )
		{
			string sMsg =	"<html>" +
							"<head>" +
							"<meta charset='utf-8'/>" +
							"</head>" +
							"<body>" +
							"<table style = 'width:50%; font-family:Verdana;'>" +
							"<thead></thead>" +
							"<tbody>" +
							"<tr>" +
							"<td style='background-color:#176562;color:white; font-size:20px; padding:10px;' colspan = '2' > " + modulo + "</td>" +
							"</tr>" +
							"<tr>" +
							"<td style='padding:20px; padding-left:10px; background-color:#808080; color:white' colspan='2'>Você recebeu uma mensagem de<b> " + nome +".</b></td>" +
							"</tr>" +
							"<tr>" +
							"<td style='padding:10px; background-color:#808080; color:white' ><b>E - mail:</b></td><td style = 'background-color:#ebebeb'><a href= 'mailto:'" + email + "' >" + email + "</a></td>" +
							"</tr>" +
							"<tr>" +
							"<td style='padding:10px; background-color:#808080; color:white'><b>Assunto:</b></td><td style = 'background-color:#ebebeb'>" + assunto + "</td>" +
							"</tr>" +
							"<tr>" +
							"<td style='padding:10px; background-color:#808080; color:white'><b>Mensagem:</b></td><td style = 'background-color:#ebebeb'>" + mensagem + "</td>" +
							"</tr>" +
							"<tr>" +
                            "<td style='background-color:#ebebeb; padding:10px; text-align:center' colspan='2'><img src='https://pucead2022clinicamedica.azurewebsites.net/Imagens/Logos/healthcare-vector_new_transp.png' width='120px;'></td>" +
							"</tr>" +
							"</tbody>" +
							"</table>" +
							"</body>" +
							"</html>";
  			return sMsg;
		}
	}	
}
