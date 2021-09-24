using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using FrameworkToolsDevelopment;

public class clsLogManager
{
    //constructor

    public FrameworkToolsDevelopment.CajeroAutomatico.LogOperating_ATM LogBitacora;
    public FrameworkToolsDevelopment.CajeroAutomatico.LogOperating_ATM LogRespaldo;
    //LogLoger
    public cinetkit.Logger LogLoger;


    public clsLogManager()
    {
        Crear_Respaldo();
        Crear_Bitacora();
        Crear_Loger();

    }

    private void existeDir(string elDirectorio)
    {
        bool existe = new bool();
        existe = Directory.Exists(elDirectorio);

        if (existe)
        {
            Console.WriteLine("El directorio {0} SI existe", elDirectorio);
        }
        else
        {
            Console.WriteLine("El directorio {0} NO existe", elDirectorio);
        }
    }

    public void Crear_Respaldo()
    {
        //Dim existe As Boolean = Directory.Exists(My.Application.Info.DirectoryPath & "\\Respaldo\\")

        bool existe = new bool();
        existe = Directory.Exists("C:\\\\LogIntegracionSoriana\\\\RespaldoApiServicios\\\\");

        //Verifica si existe o no la carpeta bitacora
        //Si no Existe la Creea
        if (existe == false)
        {
            //MkDir(My.Application.Info.DirectoryPath & "\\Respaldo\\")
            FileSystem.MkDir("C:\\\\LogIntegracionSoriana\\\\RespaldoApiServicios\\\\");

        }

        LogRespaldo = new FrameworkToolsDevelopment.CajeroAutomatico.LogOperating_ATM("C:\\\\LogIntegracionSoriana\\\\RespaldoApiServicios\\\\");
        //LogRespaldo = New cinetkit.Logger(My.Application.Info.DirectoryPath & "\\Respaldo\\")
    }

    public void Crear_Bitacora()
    {
        //Dim existe As Boolean = Directory.Exists(My.Application.Info.DirectoryPath & "\\Bitacora\\")

        bool existe = new bool();
        existe = (Directory.Exists("C:\\\\LogIntegracionSoriana\\\\BitacoraApiServicios\\\\"));

        //Verifica si existe o no la carpeta bitacora
        //Si no Existe la Creea
        if (existe == false)
        {
            //MkDir(My.Application.Info.DirectoryPath & "\\Bitacora\\")
            FileSystem.MkDir("C:\\\\LogIntegracionSoriana\\\\BitacoraApiServicios\\\\");
        }

        //LogBitacora = New cinetkit.Logger(My.Application.Info.DirectoryPath & "\\Bitacora\\")
        LogBitacora = new FrameworkToolsDevelopment.CajeroAutomatico.LogOperating_ATM("C:\\\\LogIntegracionSoriana\\\\BitacoraApiServicios\\\\");
    }

    public void Crear_Loger()
    {
        bool existe = new bool();
        existe = Directory.Exists("C:\\\\LogIntegracionSoriana\\\\LogerApiServicios\\\\");

        //Verifica si existe o no la carpeta Loger
        //Si no Existe la Creea
        if (existe == false)
        {
            FileSystem.MkDir("C:\\\\LogIntegracionSoriana\\\\LogerApiServicios\\\\");
        }

        LogLoger = new cinetkit.Logger("C:\\\\LogIntegracionSoriana\\\\LogerApiServicios\\\\");

        //LogLoger.Log = "LogCajero"
        //LogLoger.Source = "Cajero"
    }
    //'LogLogerWrite
    public void LogLogerWrite(string mess)
    {
        try
        {
            LogLoger.Write(mess);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //'LogRespaldo
    public void LogRespaldoWrite(string mess)
    {
        try
        {
            LogRespaldo.Write(mess);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //'LogBitacora
    public void LogBitacoraWrite(string mess)
    {
        try
        {
            LogBitacora.Write(mess);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}