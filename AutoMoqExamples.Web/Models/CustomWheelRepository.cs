﻿namespace AutoMoqExamples.Web.Models
{
    public class CustomWheelRepository : IWheelRepository
    {
        public object Criar(bool rodasDeLigaLeve)
        {
            return new { Personalizada = true };
        }
    }
}
