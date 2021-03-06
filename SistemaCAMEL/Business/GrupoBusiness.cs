﻿using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GrupoBusiness
    {
        GrupoData grupoData;

        public GrupoBusiness(String cadenaConexion)
        {
            grupoData = new GrupoData(cadenaConexion);
        }//ctor

        public String insertar(Grupo grupo)
        {
            return grupoData.insertar(grupo);
        }//insertar

        public LinkedList<Grupo> obtenerGrupos()
        {
            return grupoData.obtenerGrupos();
        }

        public Grupo obtenerGrupo(string seccion)
        {
            return grupoData.obtenerGrupo(seccion);
        }
        }//class
}//namespace
