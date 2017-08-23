using System;
using System.Collections.Generic;
using System.Text;

namespace AnyCore.Services.Test
{
    public class TestService : ITestService
    {
        public string Test()
        {
            return "实现了ITestService的Test方法";
        }
    }
}
