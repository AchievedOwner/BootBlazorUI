using System;
using System.Collections.Generic;
using System.Text;

using Bunit;
using Bunit.Rendering;

namespace BootBlazorUI.Test
{
    public class ElementTest
    {
        TestContext _context;
        public ElementTest()
        {
            _context = new TestContext();
            
        }

        public void TestDiv()
        {
            var div = _context.RenderComponent<Div>();

            
        }
    }
}
