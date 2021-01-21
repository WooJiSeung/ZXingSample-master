using System;
using System.Collections.Generic;
using System.Text;

namespace ZXingSample.Interface
{
    public interface IAudio
    {
        bool PlayWavSuccess();

        bool PlayWavError();
    }
}
