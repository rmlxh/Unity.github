using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeepSeekTalk : MonoBehaviour
{
    public InputField inputField;
    public Text responseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendText()
    {
        StartCoroutine(ConnetToDeepSeek());

        inputField.text = "";
        responseText.text = "DeepSeek正在深度思考中...";
    }

    public IEnumerator ConnetToDeepSeek()
    {
        using (UnityEngine.Networking.UnityWebRequest request = 
            new UnityEngine.Networking.UnityWebRequest("https://api.deepseek.com/chat/completions","POST"))
        {
            //设置请求头
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + DeepSeekConfig.APIKey);

            //设置请求体
            var requestData = new RequestData
            {
                model = "deepseek-chat",
                messages = new List<Message>
                {
                    new Message{role = "user",content = inputField.text}
                }
            };

            //将请求体转换为字节数组
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(requestData));
            //设置上传处理程序
            request.uploadHandler = new UnityEngine.Networking.UploadHandlerRaw(bodyRaw);
            //设置下载处理程序
            request.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
            //发送请求
            yield return request.SendWebRequest();

            try
            {
                //检查请求是否成功
                if(request.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
                {
                    Debug.LogError("请求失败：" + request.error);
                }
                else
                {
                    //Debug.Log("请求成功，返回内容：" + request.downloadHandler.text);
                    var response = JsonUtility.FromJson<DeepSeekResponse>(request.downloadHandler.text);
                    responseText.text = response.choices[0].message.content;
                }
            }
            catch(System.Exception e)
            {
                Debug.LogError("处理请求时出错：" + e.Message);
            }
        }

        //yield return new WaitForSeconds(3);
    }
}
