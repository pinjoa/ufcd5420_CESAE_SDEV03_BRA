// /*
// * 	<copyright file="MyException.cs" company="bitminho.com">
// * 	Copyright (c) 2023 All Rights Reserved
// * 	</copyright>
// * 	<author>João Pinto</author>
// * 	<date>20230604H16:10</date>
// * 	<description>TratamentoErros/TratamentoErros/MyException.cs</description>
// **/


using System;

namespace TratamentoErros
{
    public class MyException: ApplicationException
    {
        private MyException() : base("ERROR: n/d !!!") { }
        public MyException(string txt) : base(txt) { }
        public MyException(string txt, System.Exception e) : base(txt, e) { }
    }
}
