﻿using AutoMapper;

namespace ProjetoEstacionamento.Profiles
{
    public static class MapperConfig
    {
        public static MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new VagaProfile());
                mc.AddProfile(new VeiculoProfile());
            });
        }
    }
}
