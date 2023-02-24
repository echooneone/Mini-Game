/******************************************
 * 
 * Description: 脚本描述替换
 * 
******************************************/

using System;
using System.IO;
using UnityEngine;

namespace ScriptTemplates.Editor
{
    public class CustomScriptTemplate : UnityEditor.AssetModificationProcessor
    {
        private static String _author = "iCoove";
        private static String _companyName = "MiniGame";
        private static String _version = "1.0";

        /// <summary>
        /// 此函数在asset被创建完，文件已经生成到磁盘上，但是没有生成.meta文件和import之前被调用。
        /// </summary>
        /// <param name="newFileMeta">由创建文件的path加上.meta组成的。</param>
        public static void OnWillCreateAsset(string newFileMeta)
        {
            string newFilePath = newFileMeta.Replace(".meta", "");
            string fileExt = Path.GetExtension(newFilePath);
            if (fileExt != ".cs")
            {
                return;
            }

            // 注意，Application.dataPath 会根据使用平台不同而不同
            string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
            string scriptContent = File.ReadAllText(realPath);

            // 这里实现自定义的一些规则，这里一定要注意需要和模板中对应
            scriptContent = scriptContent.Replace("#CompanyName#", _companyName);
            scriptContent = scriptContent.Replace("#Author#", _author);
            scriptContent = scriptContent.Replace("#Version#", _version);
            scriptContent = scriptContent.Replace("#UnityVersion#", Application.unityVersion);
            scriptContent = scriptContent.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"));

            File.WriteAllText(realPath, scriptContent);
        }
    }
}