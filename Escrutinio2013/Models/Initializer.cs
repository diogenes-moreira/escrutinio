using System;
using System.Collections.Generic;
using System.Globalization;
using Castle.ActiveRecord;

namespace Escrutinio2013.Models
{
    public class Initializer
    {

        private static Categoria _diputadosNacionales;
        private static Categoria _consejales;
        private static Categoria _legisladoresProvinciales;


        public static void TratarExtranjero()
        {
            var holder = ActiveRecordMediator.GetSessionFactoryHolder();
            var sess = holder.CreateSession(typeof(Mesa));
            var conn = sess.Connection;
            var cmd = conn.CreateCommand();

            cmd.CommandText =
                "Delete From Escrutinios where CategoriaID="+ _diputadosNacionales.Id +" and MesaID in (select Id from Mesas where Numero > 8999)";
            
            cmd.ExecuteNonQuery();

            holder.ReleaseSession(sess);
        }
        
        public static void CrearCategorias()
        {
            _diputadosNacionales = new Categoria { Nombre = "Diputados Nacionales",Orden = 1, Simplificado = true};
            _diputadosNacionales.Save();
            _legisladoresProvinciales = new Categoria { Nombre = "Legisladores Provinciales", Orden = 2, Simplificado = false};
            _legisladoresProvinciales.Save();
            _consejales = new Categoria { Nombre = "Consejales y Consejeros Escolares", Orden = 3, Simplificado = true};
            _consejales.Save();

        }


        public static void CrearPartidosPoliticos()
        {
            
            CreaCombo("UNIDOS POR LA LIBERTAD Y EL TRABAJO", 1, "501");
            CreaCombo("FRENTE PARA LA VICTORIA", 2, "503");
            CreaCombo("JUNTOS POR QUILMES", 3, "763",_consejales);
            CreaCombo("FRENTE SOCIAL DE LA PCIA. DE BS. AS.", 4, "1708",_consejales);
            CreaCombo("FRENTE RENOVADOR", 5, "504");
            CreaCombo("UNION POPULAR", 6, "23", _consejales);
            CreaCombo("FRENTE DE IZQUIERDA Y DE LOS TRABAJADORES", 7, "506");
            CreaCombo("UNION CON FE", 8, "508",_diputadosNacionales);
            CreaCombo("FRENTE PROGRESISTA CIVICO Y SOCIAL", 9, "509");
            CreaCombo("FRENTE POPULAR DEMOCRATICO Y SOCIAL - PODEMOS", 10, "1703", new List<Categoria>{_legisladoresProvinciales, _consejales});
            CreaCombo("COMPROMISO FEDERAL", 11, "1701");
            CrearNoComputables();

        }

        private static void CreaCombo(string nombre, int orden, string numeroLista, IEnumerable<Categoria> categorias)
        {
            var lista = CreateHeader(nombre, orden, numeroLista);
            CrearEscrutinios(lista,categorias);
        }

        private static Lista CreateHeader(string nombre, int orden, string numeroLista)
        {
            var partido = CrearPartido(nombre, orden, numeroLista);
            var lista = CrearLista(nombre, orden, partido,true);
            return lista;
        }

        public static void CreaCombo(string nombre, int orden, string numeroLista)
        {
            var lista = CreateHeader(nombre, orden, numeroLista);
            CrearEscrutinios(lista);
        }


        public static void CreaCombo(string nombre, int orden, string numeroLista, Categoria categoria)
        {
            var lista = CreateHeader(nombre, orden, numeroLista);
            CrearEscrutinios(lista,categoria);
        }



        public static void CrearPartidosPoliticosPaso2013()
        {
            var partido = CrearPartido("GENTE EN ACCION - GEA", 1, "272");
            var lista = CrearLista("LISTA AZUL",1,partido);
            CrearEscrutinios(lista, _diputadosNacionales);
            partido = CrearPartido("M.AVANZADA SOCIALISTA - MAS", 2, "276");
            lista = CrearLista("LISTA UNICA SOB", 2, partido);
            CrearEscrutinios(lista, _diputadosNacionales);
            partido = CrearPartido("UNIDOS POR LA LIBERTAD Y EL TRABAJO", 3, "501");
            lista = CrearLista("LISTA CELESTE", 3, partido);
            CrearEscrutinios(lista);
            partido = CrearPartido("COMPROMISO FEDERAL", 4, "502");
            CrearLista("ES POSIBLE - E", 4, partido);
            CrearLista("UNIR - U", 5, partido);
            CrearLista("JUSTICIA Y DIGNIDAD - M", 6, partido);
            CrearLista("ES POSIBLE BUENOS AIRES. - P", 7, partido);
            CrearEscrutinios(partido);
            partido = CrearPartido("FRENTE PARA LA VICTORIA", 5, "503");
            lista = CrearLista("LISTA 2 - CELESTE Y BLANCA K", 8, partido,true);
            CrearEscrutinios(lista);
            partido = CrearPartido("FRENTE SOCIAL DE LA PCIA. DE BS. AS.", 6, "1708");
            lista = CrearLista("LINEA BLANCA Y CELESTE - 4", 9, partido,true);
            CrearEscrutinios(lista,  _consejales);
            partido = CrearPartido("FRENTE RENOVADOR", 7, "504");
            lista = CrearLista("CORRIENTE RENOVADORA - LISTA 1", 10, partido,true);
            CrearEscrutinios(lista);
            partido = CrearPartido("UNION POPULAR", 8, "23");
            lista = CrearLista("CORRIENTE POPULAR", 11, partido,true);
            CrearEscrutinios(lista, _consejales);
            partido = CrearPartido("FRENTE POPULAR DEMOCRATICO Y SOCIAL", 9, "505");
            lista = CrearLista("JUNTOS PODEMOS", 12, partido);
            CrearEscrutinios(lista);
            partido = CrearPartido("FRENTE POPULAR DEMOCRATICO Y SOCIAL", 10, "506");
            lista = CrearLista("LISTA 1 A", 13, partido);
            CrearEscrutinios(lista);
            partido = CrearPartido("UNION CON FE", 11, "508");
            lista = CrearLista("UNION CON FE", 14, partido);
            CrearEscrutinios(lista);
            partido = CrearPartido("FRENTE PROGRESISTA CIVICO Y SOCIAL", 12, "509");
            lista = CrearLista("UNIDAD PROGRESISTA - A", 15, partido);
            CrearEscrutinios(lista);
            lista = CrearLista("COALICION CIVICA - F", 16, partido);
            CrearEscrutinios(lista, _consejales);
            lista = CrearLista("GENTE EN QUIEN CONFIAR - D", 17, partido);
            CrearEscrutinios(lista, _consejales);
            lista = CrearLista("ACUERDO PROGRESISTA DE QUILMES - N", 18, partido);
            CrearEscrutinios(lista, _consejales);
            lista = CrearLista("TRANSP. SOLIDARIDAD Y PARTICIPACION - B", 19, partido);
            CrearEscrutinios(lista, _consejales);
            lista = CrearLista("FRENTE CIVICO POR QUILMES - MU", 20, partido);
            CrearEscrutinios(lista, _consejales);
            lista = CrearLista("PROGRESISTAS DE QUILMES - GT", 21, partido);
            CrearEscrutinios(lista, _consejales);
            lista = CrearLista("INTRANSIGENCIA Y RENOVACION - GE", 22, partido);
            CrearEscrutinios(lista, _consejales);
            lista = CrearLista("RENOVACION Y UNIDAD - NV", 23, partido);
            CrearEscrutinios(lista, _legisladoresProvinciales);
            partido = CrearPartido("PARTIDO LEALTAD Y DIGNIDAD DE BS.AS.", 13, "130");
            lista = CrearLista("LEALTAD Y DIGNIDAD", 24, partido);
            CrearEscrutinios(lista, _consejales);
            partido = CrearPartido("JUNTOS POR QUILMES", 14, " ");
            lista = CrearLista("LISTA 1 UNIDOS", 25, partido, true);
            CrearEscrutinios(lista, _consejales);

            
            CrearNoComputables();
        }

        private static void CrearNoComputables()
        {
            var partido = CrearPartido("VOTOS NO COMPUTABLES", 90, " ", true);
            CrearLista("VOTOS EN BLANCO", 91, partido);
            CrearLista("VOTOS NULOS", 92, partido);
            CrearLista("VOTOS RECURRIDOS QUE SE REMITEN EN SOBRE Nro.3", 93, partido);
            CrearLista("VOTOS DE IDENTIDAD IMPUGNADA QUE SE REMITEN EN SOBRE Nro.3", 94, partido);
            CrearEscrutinios(partido);
        }


        private static void CrearEscrutinios(PartidoPolitico partido)
        {
            CrearEscrutinios(partido, Categoria.FindAll());
        }

        private static void CrearEscrutinios(Lista lista)
        {
            CrearEscrutinios(lista, Categoria.FindAll());
        }


        private static void CrearEscrutinios(PartidoPolitico partido, IList<Categoria> categorias)
        {
            partido.Refresh();
            foreach (var lista in partido.Listas)
            {
                CrearEscrutinios(lista, categorias);
            }

        }


        private  static void CrearEscrutinios(Lista lista, IEnumerable<Categoria> categorias )
        {
            foreach (var categoria in categorias)
            {
                CrearEscrutinios(lista, categoria);    
            }
            
        }

        private static void CrearEscrutinios(Lista lista, Categoria categoria)
        {
           
            
            var holder = ActiveRecordMediator.GetSessionFactoryHolder();
            var sess = holder.CreateSession(typeof(Mesa));
            var conn = sess.Connection;
            var cmd = conn.CreateCommand();

            cmd.CommandText =
                "insert into Escrutinios(Cantidad,CategoriaId,Habilitado,ListaId, MesaId) select 0," + categoria.Id + ",1,"+ lista.Id + ",Id From Mesas";
            cmd.ExecuteNonQuery();

            holder.ReleaseSession(sess);



        }


        private static Lista CrearLista(string nombre, int orden, PartidoPolitico partido, bool simplificada = false)
        {
            var lista = new Lista
                            {
                                Nombre = nombre,
                                Orden = orden,
                                Partido = partido,
                                Simplificado = simplificada,
                            };
            lista.SaveAndFlush();
            lista.Refresh();
            return lista;
        }


        private static PartidoPolitico CrearPartido(string nombre, int orden, string numero, bool servicio = false)
        {
            var partido = new PartidoPolitico
                              {
                                  Listas = new List<Lista>(),
                                  Nombre = nombre,
                                  Orden = orden,
                                  Numero = numero,
                                  Servicio = servicio
                              };
            partido.SaveAndFlush();
            partido.Refresh();
            return partido;
        }

        public static void CrearEscuelas()
        {
            var partido = CrearPartido("Quilmes");
            var localidad = CrearLocalidad(1876,"BERNAL",partido);
            CrearEscuela("ESCUELA EP N°6", localidad, "LUIS M.DRAGO 375", "4614", "787A", 571, 582);
            CrearEscuela("ESCUELA EP N°18/ES N°38", localidad, "AVELLANEDA 177", "4615", "787A", 583, 595);
            CrearEscuela("ESCUELA EP N°23", localidad, "AV.SAN MARTIN 38", "4618", "787A", 596, 603);
            CrearEscuela("ESCUELA EP N°82/ES N°77", localidad, "YAPEYU 555", "4620", "787A", 604, 616);
            CrearEscuela("INSTITUTO MARIA AUXILIADORA", localidad, "CNEL.PRINGLES 604", "4621", "787A", 617, 619);
            CrearEscuela("INSTIT. REP. ARGENTINA", localidad, "25 DE MAYO 274", "Extranjeros", "Extranjeros", 9018, 9026);
            CrearEscuela("COLEGIO PRIVADO BERNAL", localidad, "LAVALLE 142", "Extranjeros", "Extranjeros", 9027, 9029);
            localidad = CrearLocalidad(1876, "BERNAL ESTE", partido);
            CrearEscuela("ESCUELA EP N°24/ES N°40", localidad, "CRAMER 721", "4602", "787", 530, 538);
            CrearEscuela("ESCUELA EP N°47/ES N°55", localidad, "J.LOPEZ 176", "4603", "787", 539, 547);
            CrearEscuela("ESCUELA ET N°2", localidad, "ESPORA Y CRAMER", "4607", "787", 548, 557);
            CrearEscuela("ESCUELA EP N°61", localidad, "CASEROS 890", "7393", "787", 558, 563);
            CrearEscuela("COLEGIO ALMAFUERTE", localidad, "ESTRADA 10", "4608", "787", 564, 566);
            CrearEscuela("ESCUELA ES N°11", localidad, "AV.SAN MARTIN 801", "10669", "787", 567, 570);
            localidad = CrearLocalidad(1876, "BERNAL OESTE", partido);
            CrearEscuela("ESCUELA EST N°8", localidad, "175 BIS E/PILCOMAYO Y PAMPA", "11592", "788", 720, 725);
            localidad = CrearLocalidad(1877, "DON BOSCO", partido);
            CrearEscuela("JARDIN DE INFANTES N°911", localidad, "RIVADAVIA 248", "9240", "786", 434, 437);
            CrearEscuela("ESCUELA ES N°1", localidad, "LOS ANDES 173", "7174", "786", 445, 457);
            CrearEscuela("ESCUELA EP N°42", localidad, "LOS ANDES 175", "4586", "786", 458, 469);
            CrearEscuela("ESCUELA EP N°46/ES N°83", localidad, "CHICLANA 1019", "4587", "786", 470, 477);
            CrearEscuela("ESCUELA MODELO M.ACOSTA", localidad, "A.ALVAREZ 64", "4589", "786", 478, 479);
            CrearEscuela("COLEGIO JUAN XXIII", localidad, "MAIPU 1056", "4590", "786", 480, 483);
            localidad = CrearLocalidad(1878, "QUILMES", partido);
            CrearEscuela("COLEGIO SAN FELIPE BENIZI", localidad, "SAENZ PEÑA 1446", "4560", "785", 223, 228);
            CrearEscuela("INSTITUTO SAN MARCO", localidad, "PTE.PERON 1033", "11564", "785", 255, 261);
            CrearEscuela("ESCUELA EP N 36", localidad, "RCA. DEL LIBANO 1532", "Extranjeros", "Extranjeros", 9001, 9003);
            localidad = CrearLocalidad(1878, "QUILMES (PARTE)", partido);
            CrearEscuela("ESCUELA EP N°30/ES N°43", localidad, "OTTO BEMBERG 293", "4547", "785", 157, 172);
            CrearEscuela("ESCUELA EP N°17", localidad, "ENTRE RIOS 580", "4548", "785", 173, 181);
            CrearEscuela("ESCUELA EP N°22", localidad, "RCA.DEL LIBANO 161", "4549", "785", 182, 187);
            CrearEscuela("ESCUELA EP N°16/ES N°37", localidad, "R.LOPEZ 533", "4550", "785", 188, 196);
            CrearEscuela("INSTITUTO MODELO JEAN PIAGET", localidad, "BERUTTI 1355", "4564", "785", 197, 202);
            CrearEscuela("ESCUELA EP N°13", localidad, "12 DE OCTUBRE 758", "4552", "785", 203, 212);
            CrearEscuela("TALLER DIVINA PROVIDENCIA", localidad, "SAENZ PEÑA 1407", "4553", "785", 213, 216);
            CrearEscuela("ESCUELA ES N°3", localidad, "CORRIENTES 587", "4554", "785", 217, 222);
            CrearEscuela("ESCUELA EP N°12/ES N°49", localidad, "F.AMOEDO 1256", "4555", "785", 229, 236);
            CrearEscuela("ESCUELA EP N°83/ES N°26", localidad, "URQUIZA 1197", "4551", "785", 237, 247);
            CrearEscuela("INSTITUTO NTRA.SRA.DE FATIMA", localidad, "CONDARCO 2469", "4558", "785", 248, 254);
            localidad = CrearLocalidad(1878, "QUILMES ESTE", partido);
            CrearEscuela("INSTITUTO SAN JOSE", localidad, "MITRE 460", "9925", "783", 23, 30);
            CrearEscuela("INSTITUTO RIOS DE VIDA", localidad, "MARMOL 500", "7168", "784", 90, 95);
            CrearEscuela("ESCUELA EP N°9", localidad, "MORENO 932", "4539", "784", 109, 115);
            localidad = CrearLocalidad(1878, "QUILMES ESTE (PARTE)", partido);
            CrearEscuela("ESCUELA EP N°7/ES N°31", localidad, "ALBERDI 130", "4520", "783", 1, 10);
            CrearEscuela("COLEGIO NAZARETH", localidad, "GRAL.CONESA 406", "4521", "783", 11, 14);
            CrearEscuela("ESCUELA ES N°20", localidad, "MITRE 364", "4522", "783", 15, 22);
            CrearEscuela("ESCUELA EST N°4", localidad, "VIDELA 226", "4523", "783", 31, 35);
            CrearEscuela("COLEGIO MANUEL BELGRANO", localidad, "RIVADAVIA 460", "4524", "783", 36, 45);
            CrearEscuela("COLEGIO PRESBITERO BRUZZONE", localidad, "SAN MARTIN Y SAAVEDRA", "4526", "783", 46, 50);
            CrearEscuela("COLEGIO E.HOLMBERG", localidad, "SARMIENTO 679", "4527", "783", 51, 55);
            CrearEscuela("ESCUELA EP N°19/ES N°7", localidad, "ORTIZ DE OCAMPO 335", "4538", "784", 96, 108);
            CrearEscuela("ESCUELA ES N°15", localidad, "A.BOTTARO 1125", "4540", "784", 116, 130);
            CrearEscuela("ESCUELA EP N°28/ES N°12", localidad, "AGRIGENTO 475", "4545", "784", 131, 144);
            CrearEscuela("ESCUELA EP N°38", localidad, "ECHEVERRIA 192", "4541", "784", 145, 150);
            CrearEscuela("ESCUELA EP N°73", localidad, "AGRIGENTO E/CEVALLOS Y MONROE", "4542", "784", 151, 154);
            CrearEscuela("COLEGIO MONSEÑOR DI PASQUO", localidad, "PRIMERA JUNTA 750", "4543", "784", 155, 156);
            CrearEscuela("CTRO.EDUC.COMPLEMENTARIO N°1", localidad, "OTAMENDI 1504", "9254", "783A", 56, 59);
            CrearEscuela("ESCUELA EP N°79", localidad, "MARINERO LOPEZ 575", "4533", "783A", 60, 69);
            CrearEscuela("ESCUELA ESPECIAL N°506", localidad, "ALSINA E/MARINERO LOPEZ Y 91", "4534", "783A", 70, 74);
            CrearEscuela("ESCUELA EP N°39", localidad, "MOZART Y BALCARCE", "4535", "783A", 75, 83);
            CrearEscuela("ESCUELA EP N°10", localidad, "HUMBERTO I N°887", "9977", "783A", 84, 89);
            localidad = CrearLocalidad(1879, "QUILMES", partido);
            CrearEscuela("ESCUELA EST N°1", localidad, "ANDRADE 800", "11922", "791A", 1144, 1150);           
            localidad = CrearLocalidad(1879, "QUILMES OESTE", partido);
            CrearEscuela("ESCUELA EP. N 35", localidad, "CRAVIOTTO Y M. CANE", "Extranjeros", "Extranjeros", 9036, 9042);
            CrearEscuela("ESCUELA ES N°16", localidad, "AV.CALCHAQUI 840", "7170", "785A", 262, 270);
            CrearEscuela("INST.DR.ALEXANDER FLEMING", localidad, "ESTANISLAO DEL CAMPO 1825", "7181", "785A", 316, 317);
            CrearEscuela("ESCUELA EP N°41", localidad, "RESISTENCIA 1395", "9224", "785B", 381, 386);
            CrearEscuela("ESCUELA EP N°8/ES N°32", localidad, "381 N°2323 Y AYOLAS", "4580", "785B", 387, 403);
            CrearEscuela("ESCUELA EP N°76/ES N°74", localidad, "809 N°1890 Y 889", "4662", "788C", 999, 1007);
            CrearEscuela("ESCUELA EP N°55", localidad, "J.B.JUSTO 3402", "4683", "791B", 1151, 1166);
            CrearEscuela("ESCUELA ET N°6", localidad, "AV.CALCHAQUI 1894", "4568", "785A", 271, 285);
            CrearEscuela("ESCUELA EP N°81/ES N°25", localidad, "ENTRE RIOS 2812", "4569", "785A", 286, 299);
            CrearEscuela("ESCUELA EP N°26/ES N°81", localidad, "J.V.GONZALEZ 751", "4570", "785A", 300, 309);
            CrearEscuela("ESCUELA EP N°62", localidad, "LA RIOJA 1637", "4573", "785B", 318, 328);
            CrearEscuela("INSTITUTO SAGRADA FAMILIA", localidad, "AV.CALCHAQUI 1251", "4574", "785B", 329, 337);
            CrearEscuela("ESCUELA SAN CLEMENTE", localidad, "SAN MAURO CASTELVERDE 4044", "4575", "785B", 338, 344);
            CrearEscuela("ESCUELA EP N°27", localidad, "SAN LUIS 4016-B°LA PRIMAVERA", "4576", "785B", 345, 351);
            CrearEscuela("NTRA.SRA.DEL PERPETUO SOCORRO", localidad, "AV.CALCHAQUI 4949", "4577", "785B", 352, 362);
            CrearEscuela("INSTITUTO CRISTO REY", localidad, "389 N°1964 E/AMOEDO-P.GALDOS", "7172", "785B", 363, 368);
            CrearEscuela("ESCUELA EP N°71", localidad, "339 N°3351 E/384 Y 385", "4578", "785B", 369, 380);
            CrearEscuela("ESCUELA EP N°75", localidad, "CHILE E IRALA", "4581", "785B", 404, 412);
            CrearEscuela("ESCUELA EP N°56", localidad, "OTAMENDI 603", "9226", "785B", 413, 418);
            CrearEscuela("ESCUELA EP N°37", localidad, "RCA.DEL LIBANO 5070", "4582", "785B", 419, 427);
            CrearEscuela("COLEGIO SANTO DOMINGO", localidad, "344 N°3202", "9496", "785B", 428, 433);
            CrearEscuela("ESCUELA EP N°68/ES N°67", localidad, "819 N°921", "7415", "788B", 865, 874);
            CrearEscuela("ESCUELA EP N°25", localidad, "802 Y 897", "4658", "788C", 941, 954);
            CrearEscuela("COLEGIO MADRE TERESA", localidad, "SANTA FE 1865 E/888 Y 889", "4659", "788C", 955, 973);
            CrearEscuela("ESCUELA EP N°2/ES N°2", localidad, "806 N°2374 E/893 Y 894", "4660", "788C", 974, 988);
            CrearEscuela("ESCUELA ES N°9", localidad, "810 N°1828", "9229", "788C", 989, 998);
            CrearEscuela("INSTITUTO MALVINAS ARGENTINAS", localidad, "816 N°2409", "7179", "788C", 1008, 1017);
            CrearEscuela("ESCUELA EP N°77", localidad, "820 E/892 Y 893 S/N", "4661", "788C", 1018, 1022);
            CrearEscuela("INSTITUTO CONSTANCIO C.VIGIL", localidad, "L.AGOTE (339)N°2823", "4684", "791B", 1167, 1177);
            CrearEscuela("ESCUELA EP N°3", localidad, "AV.LA PLATA 1751", "4571", "785A", 310, 315);
            CrearEscuela("ESCUELA SECUND. MIGUEL CANE", localidad, "MIGUEL CANE Y LAPRIDA", "Extranjeros", "Extranjeros", 9004, 9017);
            localidad = CrearLocalidad(1881, "EZPELETA OESTE", partido);
            CrearEscuela("ESCUELA EP N°85", localidad, "CONDARCO 5350", "4685", "791B", 1178, 1190);
            CrearEscuela("ESCUELA EP N°66/ES N°21", localidad, "J.B.JUSTO 4851", "4686", "791B", 1191, 1206);
            CrearEscuela("ESCUELA EP N°34/ES N°45", localidad, "ROJAS 5659", "4687", "791B", 1207, 1221);
            CrearEscuela("ESCUELA EP N°54/ES N°22", localidad, "BRASIL Y E.DEL CAMPO", "4689", "791B", 1222, 1225);
            localidad = CrearLocalidad(1881, "SAN FCO.SOLANO", partido);
            CrearEscuela("ESCUELA EP. N 50", localidad, "826 E/ 897 Y 898", "Extranjeros", "Extranjeros", 9030, 9035);
            CrearEscuela("ESCUELA EP N°53", localidad, "844 N°2288", "4636", "788A", 726, 737);
            CrearEscuela("ESCUELA EP N°64", localidad, "AV.PROVINCIAL Y 849", "4637", "788A", 738, 746);
            CrearEscuela("ESCUELA EP N°80", localidad, "891 N°3121", "4639", "788A", 759, 771);
            CrearEscuela("INSTITUTO JOSE MANUEL ESTRADA", localidad, "892 N°4051 E/840 Y 841", "4640", "788A", 772, 781);
            CrearEscuela("ESCUELA ES N°2", localidad, "844 N°2257 E/893 Y 894", "4641", "788A", 782, 797);
            CrearEscuela("INSTITUTO JOSE HERNANDEZ", localidad, "DONATO ALVAREZ E/824 Y 823", "4647", "788A", 798, 804);
            CrearEscuela("ESCUELA EP N°11", localidad, "895 E/835 Y 836", "4642", "788A", 805, 814);
            CrearEscuela("ESCUELA ES N°10", localidad, "899 E/MONTEVERDE Y 859", "9259", "788A", 815, 820);
            CrearEscuela("ESCUELA EP N°32", localidad, "844 N°2270 E/893 Y 894", "4643", "788A", 821, 836);
            CrearEscuela("INST.SAN JUAN BAUTISTA", localidad, "835 N°1789 ESQ.888", "9264", "788A", 837, 840);
            CrearEscuela("ESCUELA EP N°57/ES N°18", localidad, "865 N°2737", "4644", "788A", 841, 854);
            CrearEscuela("INST.ALFONSINA STORNI", localidad, "851 N°2251 E/893 Y 894", "9257", "788A", 855, 864);
            CrearEscuela("ESCUELA EP N°4", localidad, "827 N°2525", "4638", "788A", 747, 758);
            localidad = CrearLocalidad(1881, "VILLA LA FLORIDA", partido);
            CrearEscuela("ESCUELA EP N°51/ES N°57", localidad, "874 N°4983 E/850 Y 852", "4650", "788B", 875, 887);
            CrearEscuela("ESCUELA EP N°43", localidad, "880 Y 833", "4651", "788B", 888, 900);
            CrearEscuela("COLEGIO SAN JOSE OBRERO", localidad, "873 N°4518 E/844 Y 846", "4653", "788B", 901, 909);
            CrearEscuela("INSTITUTO SAN GABRIEL", localidad, "877 N°4728", "7178", "788B", 910, 912);
            CrearEscuela("ESCUELA EP N°40/ES N°40", localidad, "839 N°546 E/876 Y 877", "4655", "788B", 913, 921);
            CrearEscuela("ESCUELA EP N°86/ES N°79", localidad, "849 ESQ.883", "4656", "788B", 922, 933);
            CrearEscuela("ESCUELA EP N°45/ES N°54", localidad, "846 N°1202 Y 882", "4649", "788B", 934, 940);
            localidad = CrearLocalidad(1882, "EZPELETA", partido);
            CrearEscuela("ESCUELA ES N°5", localidad, "RIO SALADO 5150", "4669", "791", 1069, 1077);
            CrearEscuela("ESCUELA EP N°44/ES N°53", localidad, "PANAMA N°420", "4672", "791A", 1078, 1084);
            CrearEscuela("SOCIEDAD DE FOMENTO EZPELETA", localidad, "AV.SAN MARTIN 5471", "4673", "791A", 1085, 1086);
            CrearEscuela("ESCUELA EP N°69/ES N°68", localidad, "LARREA N°3922", "4674", "791A", 1087, 1096);
            CrearEscuela("ESCUELA EP N°52/ES N°17", localidad, "MINUTO 4849", "4676", "791A", 1109, 1120);
            CrearEscuela("INSTITUTO ESTEBAN ECHEVERRIA", localidad, "BRASIL 1450", "7182", "791A", 1121, 1126);
            CrearEscuela("ESCUELA EP N°74/ES N°72", localidad, "V.LOPEZ N°3980", "4679", "791A", 1127, 1137);
            localidad = CrearLocalidad(1882, "EZPELETA (PARTE)", partido);
            CrearEscuela("ESCUELA EP N°14", localidad, "CARBONARI N°379", "4664", "791", 1023, 1034);
            CrearEscuela("JARDIN DE INFANTES N°920", localidad, "SALTA 1359", "4666", "791", 1035, 1037);
            CrearEscuela("ESCUELA EP N°67/ES N°66", localidad, "E.ZOLA N°4799", "4667", "791", 1038, 1044);
            CrearEscuela("ESCUELA EP N°5", localidad, "MENDOZA N°187", "4668", "791", 1045, 1050);
            CrearEscuela("ESCUELA EP N°49/ES N°56", localidad, "RIO DESAGUADERO 5180", "4670", "791", 1051, 1059);
            CrearEscuela("INSTITUTO JOAQUIN V.GONZALEZ", localidad, "LA GUARDA 234", "7180", "791", 1060, 1064);
            CrearEscuela("INST.PRIVADO J.B.ALBERDI", localidad, "LAVALLE 5056", "9248", "791", 1065, 1068);
            CrearEscuela("COLEG.STA.TERESITA DEL NIÑO JE", localidad, "AV.SAN MARTIN 5455", "4675", "791A", 1097, 1108);
            CrearEscuela("COL.STA.T.DEL NIÑO JESUS(SEC)", localidad, "DOMINGO SOBRAL 213", "9251", "791A", 1138, 1143);
            localidad = CrearLocalidad(1883, "BERNAL OESTE", partido);
            CrearEscuela("INSTITUTO TINKUNACO", localidad, "174 ESQ.FORMOSA", "11070", "788", 654, 655);
            CrearEscuela("ESCUELA EP N°48", localidad, "ALEM 1545", "4597", "786A", 509, 520);
            CrearEscuela("ESCUELA EP N°20", localidad, "ZAPIOLA 1170", "4624", "787A", 634, 643);
            localidad = CrearLocalidad(1883, "BERNAL OESTE (PARTE)", partido);
            CrearEscuela("ESCUELA EP N°31", localidad, "DARDO ROCHA 1343", "4584", "786", 438, 444);
            CrearEscuela("INSTITUTO BENITO GONZALEZ", localidad, "MISIONES 1024", "4592", "786", 484, 486);
            CrearEscuela("CLUB BERNAL OESTE", localidad, "MONTEVIDEO 943", "4593", "786", 487, 488);
            CrearEscuela("ESCUELA EP N°65", localidad, "LOS ANDES Y MALV.ARGENTINAS", "4628", "788", 644, 653);
            CrearEscuela("ESCUELA EP N°63", localidad, "187 N°609", "4629", "788", 656, 664);
            CrearEscuela("ESC.EDUC.MEDIA N°13/ES N°20", localidad, "LA PAMPA 4324", "4630", "788", 665, 672);
            CrearEscuela("ESCUELA EP N°60", localidad, "190 Y LINIERS S/N°", "4631", "788", 673, 682);
            CrearEscuela("ESCUELA EP N°33", localidad, "CABO SESSA 1101", "4632", "788", 683, 697);
            CrearEscuela("SOC.DE FOMENTO 25 DE MAYO", localidad, "CISTERNA 3441", "4633", "788", 698, 701);
            CrearEscuela("ESCUELA EP N°72/ES N°70", localidad, "BOEDO 1253", "4634", "788", 702, 714);
            CrearEscuela("ESCUELA EP N°70", localidad, "DONATO ALVAREZ Y ARMESTI", "11060", "788", 715, 719);
            CrearEscuela("ESCUELA EP N°15", localidad, "167 Y CERRITO", "4595", "786A", 489, 497);
            CrearEscuela("ESC.EDUC.MEDIA N°6/ES N°15", localidad, "ALEM 1545", "4596", "786A", 498, 508);
            CrearEscuela("ESCUELA EP N°78/ES N°23", localidad, "CHACO 1540", "4598", "786A", 521, 527);
            CrearEscuela("JARDIN DE INFANTES N°943", localidad, "FORMOSA 1555", "9273", "786A", 528, 529);
            CrearEscuela("ESCUELA EP N°21", localidad, "DARDO ROCHA Y CERRITO", "4622", "787A", 620, 633);
        }


        private static void CrearEscuela(string nombre, Localidad localidad, string direccion, string codigo, string circuito, int mesaDesde, int mesaHasta)
        {
            var escuela = new Escuela
                             {
                                 Circuito = circuito,
                                 Codigo = codigo,
                                 Direccion = direccion,
                                 Localidad = localidad,
                                 Mesas = new List<Mesa>(),
                                 Nombre = nombre,
                                 MesaDesde = mesaDesde,
                                 MesaHasta = mesaHasta
                             };
            escuela.SaveAndFlush();
            escuela.Refresh();
            for (var i = mesaDesde; i < mesaHasta + 1; i++ )
            {
                 new Mesa
                     {
                         Escrutinios = new List<Escrutinio>(),
                         Escuela = escuela,
                         Numero = i.ToString(CultureInfo.InvariantCulture),
                         Entregada = false,
                     }.SaveAndFlush();                       
            }
           
        }


        private static Localidad CrearLocalidad(int codigoPostal, String nombre, Partido partido)
        {
            var salida = new Localidad
                             {
                                 CodigoPostal = codigoPostal,
                                 Escuelas = new List<Escuela>(),
                                 Nombre = nombre,
                                 Partido = partido
                             };
            salida.SaveAndFlush();
            salida.Refresh();
            return salida;
        }

        private static Partido CrearPartido(String nombre)
        {
            var salida= new Partido
                            {
                           Nombre = nombre,
                           Localidades = new List<Localidad>()
                       };
            salida.SaveAndFlush();
            salida.Refresh();
            return salida;
        }


    }
}