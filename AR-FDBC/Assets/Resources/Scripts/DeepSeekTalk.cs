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
        responseText.text = "DeepSeek�������˼����...";
    }

    public IEnumerator ConnetToDeepSeek()
    {
        using (UnityEngine.Networking.UnityWebRequest request = 
            new UnityEngine.Networking.UnityWebRequest("https://api.deepseek.com/chat/completions","POST"))
        {
            //��������ͷ
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + DeepSeekConfig.APIKey);

            //����������
            var requestData = new RequestData
            {
                model = "deepseek-chat",
                messages = new List<Message>
                {
                    new Message{role = "user",content = inputField.text}
                }
            };

            //��������ת��Ϊ�ֽ�����
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(requestData));
            //�����ϴ��������
            request.uploadHandler = new UnityEngine.Networking.UploadHandlerRaw(bodyRaw);
            //�������ش������
            request.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
            //��������
            yield return request.SendWebRequest();

            try
            {
                //��������Ƿ�ɹ�
                if(request.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
                {
                    Debug.LogError("����ʧ�ܣ�" + request.error);
                }
                else
                {
                    //Debug.Log("����ɹ����������ݣ�" + request.downloadHandler.text);
                    var response = JsonUtility.FromJson<DeepSeekResponse>(request.downloadHandler.text);
                    responseText.text = response.choices[0].message.content;
                }
            }
            catch(System.Exception e)
            {
                Debug.LogError("��������ʱ����" + e.Message);
            }
        }

        //yield return new WaitForSeconds(3);
    }
}
