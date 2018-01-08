using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {


        public static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            sw.Stop();

            #region 使用catch处理
            sw.Reset();
            sw.Start();
            try
            {
                throw new ErrorCodeException();
            }
            catch (ErrorCodeException ex)
            {
                Console.WriteLine(ex.ErrorCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);//161左右
            Console.WriteLine();
            #endregion


            #region 使用is来判断，再使用强制转型
            sw.Reset();
            sw.Start();
            try
            {
                throw new ErrorCodeException();
            }
            catch (Exception ex)
            {
                if (ex is ErrorCodeException)
                {
                    var errCode = ((ErrorCodeException)ex).ErrorCode;
                    Console.WriteLine(errCode);
                }
                
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);//350左右
            Console.WriteLine();
            #endregion

            

            #region 使用as来处理
            sw.Reset();
            sw.Start();
            try
            {
                throw new ErrorCodeException();
            }
            catch (Exception ex)
            {
                var errCodeEx = ex as ErrorCodeException;
                if (errCodeEx != null)
                {
                    var errCode = errCodeEx.ErrorCode;
                    Console.WriteLine(errCode);
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);//139左右
            Console.WriteLine();
            #endregion

            

            
        }

    }

    class ErrorCodeException : Exception
    {
        public string ErrorCode { get; private set; }

        public ErrorCodeException()
        {
            
        }
    }



}
