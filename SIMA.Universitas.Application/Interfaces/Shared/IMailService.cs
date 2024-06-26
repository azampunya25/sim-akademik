﻿using SIMA.Universitas.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace SIMA.Universitas.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}