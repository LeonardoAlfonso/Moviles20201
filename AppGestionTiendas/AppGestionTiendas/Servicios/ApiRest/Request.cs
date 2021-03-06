﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppGestionTiendas.Models.ModelosAuxiliares;

namespace AppGestionTiendas.Servicios.ApiRest
{
    public abstract class Request<T>
    {
        #region Properties
        protected string Url { get; set; }
        protected string Verbo { get; set; }
        protected string UrlParameters { get; set; }

        private static ServicioHeaders servicioHeaders;

        #endregion Properties

        #region Getters / Setters
        protected static ServicioHeaders ServicioHeaders
        {
            get
            {
                if (servicioHeaders == null)
                {
                    servicioHeaders = new ServicioHeaders();
                }
                return servicioHeaders;
            }
        }
        #endregion Getters / Setters

        #region Métodos
        public abstract Task<APIResponse> SendRequest(T objecto);

        public async Task ContruirURL(ParametersRequest parametros)
        {
            ParametersRequest Parametros = parametros as ParametersRequest;
            string newURL = Url;

            if (Parametros.Parametros.Count > 0)
            {
                newURL = (newURL.Substring(Url.Length - 1) == "/") ? newURL.Remove(newURL.Length - 1) : newURL;
                Parametros.Parametros.ForEach(p => newURL += "/" + p);
            }

            if (Parametros.QueryParametros.Count > 0)
            {
                var queryParameters = await new FormUrlEncodedContent(Parametros.QueryParametros).ReadAsStringAsync();
                newURL += queryParameters;
            }

            UrlParameters = newURL;
        }

        #endregion Métodos
    }
}
