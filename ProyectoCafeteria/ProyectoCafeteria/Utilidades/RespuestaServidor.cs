using ProyectoCafeteria.Properties.Langs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Utilidades
{
    public static class RespuestaServidor
    {
        public static string TraducirCodigo(int codigoHttp)
        {
            string mensaje = " ";
            switch (codigoHttp)
            {
                case 100:
                    mensaje = Lang.CodigoEstadoHTTP100;
                    break;
                case 101:
                    mensaje = Lang.CodigoEstadoHTTP101;
                    break;
                case 102:
                    mensaje = Lang.CodigoEstadoHTTP102;
                    break;
                case 103:
                    mensaje = Lang.CodigoEstadoHTTP103;
                    break;
                case 200:
                    mensaje = Lang.CodigoEstadoHTTP200;
                    break;
                case 201:
                    mensaje = Lang.CodigoEstadoHTTP201;
                    break;
                case 202:
                    mensaje = Lang.CodigoEstadoHTTP202;
                    break;
                case 203:
                    mensaje = Lang.CodigoEstadoHTTP203;
                    break;
                case 204:
                    mensaje = Lang.CodigoEstadoHTTP204;
                    break;
                case 205:
                    mensaje = Lang.CodigoEstadoHTTP205;
                    break;
                case 206:
                    mensaje = Lang.CodigoEstadoHTTP206;
                    break;
                case 207:
                    mensaje = Lang.CodigoEstadoHTTP207;
                    break;
                case 226:
                    mensaje = Lang.CodigoEstadoHTTP226;
                    break;
                case 300:
                    mensaje = Lang.CodigoEstadoHTTP300;
                    break;
                case 301:
                    mensaje = Lang.CodigoEstadoHTTP301;
                    break;
                case 302:
                    mensaje = Lang.CodigoEstadoHTTP302;
                    break;
                case 303:
                    mensaje = Lang.CodigoEstadoHTTP303;
                    break;
                case 304:
                    mensaje = Lang.CodigoEstadoHTTP304;
                    break;
                case 305:
                    mensaje = Lang.CodigoEstadoHTTP305;
                    break;
                case 306:
                    mensaje = Lang.CodigoEstadoHTTP306;
                    break;
                case 307:
                    mensaje = Lang.CodigoEstadoHTTP307;
                    break;
                case 308:
                    mensaje = Lang.CodigoEstadoHTTP308;
                    break;
                case 400:
                    mensaje = Lang.CodigoEstadoHTTP400;
                    break;
                case 401:
                    mensaje = Lang.CodigoEstadoHTTP401;
                    break;
                case 402:
                    mensaje = Lang.CodigoEstadoHTTP402;
                    break;
                case 403:
                    mensaje = Lang.CodigoEstadoHTTP403;
                    break;
                case 404:
                    mensaje = Lang.CodigoEstadoHTTP404;
                    break;
                case 405:
                    mensaje = Lang.CodigoEstadoHTTP405;
                    break;
                case 406:
                    mensaje = Lang.CodigoEstadoHTTP406;
                    break;
                case 407:
                    mensaje = Lang.CodigoEstadoHTTP407;
                    break;
                case 408:
                    mensaje = Lang.CodigoEstadoHTTP408;
                    break;
                case 409:
                    mensaje = Lang.CodigoEstadoHTTP409;
                    break;
                case 410:
                    mensaje = Lang.CodigoEstadoHTTP410;
                    break;
                case 411:
                    mensaje = Lang.CodigoEstadoHTTP411;
                    break;
                case 412:
                    mensaje = Lang.CodigoEstadoHTTP412;
                    break;
                case 413:
                    mensaje = Lang.CodigoEstadoHTTP413;
                    break;
                case 414:
                    mensaje = Lang.CodigoEstadoHTTP414;
                    break;
                case 415:
                    mensaje = Lang.CodigoEstadoHTTP415;
                    break;
                case 416:
                    mensaje = Lang.CodigoEstadoHTTP416;
                    break;
                case 417:
                    mensaje = Lang.CodigoEstadoHTTP417;
                    break;
                case 418:
                    mensaje = Lang.CodigoEstadoHTTP418;
                    break;
                case 421:
                    mensaje = Lang.CodigoEstadoHTTP421;
                    break;
                case 422:
                    mensaje = Lang.CodigoEstadoHTTP422;
                    break;
                case 423:
                    mensaje = Lang.CodigoEstadoHTTP423;
                    break;
                case 424:
                    mensaje = Lang.CodigoEstadoHTTP424;
                    break;
                case 426:
                    mensaje = Lang.CodigoEstadoHTTP426;
                    break;
                case 428:
                    mensaje = Lang.CodigoEstadoHTTP428;
                    break;
                case 429:
                    mensaje = Lang.CodigoEstadoHTTP429;
                    break;
                case 431:
                    mensaje = Lang.CodigoEstadoHTTP431;
                    break;
                case 451:
                    mensaje = Lang.CodigoEstadoHTTP451;
                    break;
                case 500:
                    mensaje = Lang.CodigoEstadoHTTP500;
                    break;
                case 501:
                    mensaje = Lang.CodigoEstadoHTTP501;
                    break;
                case 502:
                    mensaje = Lang.CodigoEstadoHTTP502;
                    break;
                case 503:
                    mensaje = Lang.CodigoEstadoHTTP503;
                    break;
                case 504:
                    mensaje = Lang.CodigoEstadoHTTP504;
                    break;
                case 505:
                    mensaje = Lang.CodigoEstadoHTTP505;
                    break;
                case 506:
                    mensaje = Lang.CodigoEstadoHTTP506;
                    break;
                case 507:
                    mensaje = Lang.CodigoEstadoHTTP507;
                    break;
                case 508:
                    mensaje = Lang.CodigoEstadoHTTP508;
                    break;
                case 510:
                    mensaje = Lang.CodigoEstadoHTTP510;
                    break;
                case 511:
                    mensaje = Lang.CodigoEstadoHTTP511;
                    break;
                default:
                    mensaje = Lang.CodigoEstadoHTTP_NO_REGISTRADO;
                    break;
            }
            return mensaje;
        }
    }
}
