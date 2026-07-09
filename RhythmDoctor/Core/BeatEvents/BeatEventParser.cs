using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmDoctor.Core.BeatEvents
{
    public class BeatEventParser
    {
        public BeatEvent ParseBeatEvent(string str)
        {
            string eventName = str;
            List<string> parameters = null;

            if (str.Contains("(") && str.Contains(")"))
            {
                int openIndex = str.IndexOf('(');
                int closeIndex = str.LastIndexOf(')');

                eventName = str.Substring(0, openIndex).Trim();
                string parameterText = str.Substring(openIndex + 1, closeIndex - openIndex - 1);
                parameters = parameterText.Split('-').ToList();
            }
            else
            {
                eventName = str;
            }

            return Parse(eventName, parameters);
        }

        /*
        SetTimingBar(int)
        RenderImage(레이어명, 이미지명, 띄울 행, 띄울 열)
        ActiveHitBeat
        */
        BeatEvent Parse(string eventName, List<string> parameters)
        {
            switch (eventName)
            {
                case "SetTimingBar":
                    if (parameters != null && parameters.Count == 1
                    && int.TryParse(parameters[0], out int p_STB)
                    )
                        return new SetTimingBar(p_STB);
                    else
                        return new SetTimingBar(1);
                case "RenderImage":
                    if (parameters != null && parameters.Count == 4
                    && Enum.TryParse<RenderLayer>(parameters[0], out RenderLayer p_RI_1)
                    && int.TryParse(parameters[2], out int p_RI_3)
                    && int.TryParse(parameters[3], out int p_RI_4)
                    )
                        return new RenderImage(p_RI_1, parameters[1], p_RI_3, p_RI_4);
                    else
                        return new RenderImage(RenderLayer.Background, "", 0, 0);
                case "ActiveHitBeat":
                    if (parameters != null && parameters.Count == 2
                    && int.TryParse(parameters[0], out int p_AHB_0)
                    && int.TryParse(parameters[1], out int p_AHB_1)
                    )
                        return new ActiveHitBeat(p_AHB_0, p_AHB_1);
                    else
                        return new ActiveHitBeat();
                case "PlaySFX":
                    if (parameters != null && parameters.Count == 1)
                        return new PlaySFX(parameters[0]);
                    else
                        return new PlaySFX("");

                case "ActiveRendering":
                    if (parameters != null && parameters.Count == 2
                        && Enum.TryParse<RenderLayer>(parameters[0], out RenderLayer p_AR_1)
                        && bool.TryParse(parameters[1], out bool p_AR_2)
                        )
                        return new ActiveRendering(p_AR_1, p_AR_2);
                    else
                        return new ActiveRendering(RenderLayer.Background, true);
            }

            return null;
        }
    }
}
