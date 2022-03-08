using Store.ApplicationCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Store.UnitTests.Utils
{
    public class DateUtilTests
    {
        [Fact]
        public void GetCurrentDate_ReturnsCorrectDate()
        {
            var currentDate = DateUtil.GetCurrentDate();

            Assert.True(currentDate.Year >= 2022);
        }
    }
}
