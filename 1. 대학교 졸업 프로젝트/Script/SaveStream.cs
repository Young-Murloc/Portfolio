using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Key와 Value 개념으로 파일을 쓰고 읽을 수 있도록 해주는 클래스, 싱글톤 이용
public class SaveStream
{
    private static SaveStream instance = null; // 싱글톤 인스턴스
    string filename; // 파일 이름
    FileStream file; // 파일 스트림
    StreamWriter sw; // 스트림 쓰기
    StreamReader sr; // 스트림 읽기
    Dictionary<string, string> dic = new Dictionary<string, string>(); // Key와 Value 개념의 사전 자료구조

    // 생성자
    private SaveStream()
    {
        filename = Application.persistentDataPath + "/Save_File.txt"; // 파일 이름 지정
    }

    // 싱글톤 인스턴스 얻기
    public static SaveStream GetInstance()
    {
        if(instance == null) // 없다면
        {
            instance = new SaveStream(); // 새로 생성
        }

        return instance; // 반환
    }

    // 쓰기 시작
    public void openWrite()
    {
        file = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite); // 파일 스트림 객체 생성
        sw = new StreamWriter(file); // 스트림 쓰기 객체 생성
    }
    
    // 읽기 시작
    public void openRead()
    {
        file = new FileStream(filename, FileMode.Open, FileAccess.Read); // 파일 스트림 객체 생성
        sr = new StreamReader(file); // 스트림 읽기 객체 생성

        string keyAndValue; // 키와 값, Key=Value 형식
        string[] kv; // 배열로 분리 됨
        char sep = '='; // 분리할 문자, =으로 분리

        for(int i=0; i<4; i++) // 4개의 세트 얻기
        {
            keyAndValue = sr.ReadLine(); // 라인 읽기
            //Debug.Log(keyAndValue); 디버깅용

            kv = keyAndValue.Split(sep); // sep으로 분리하여 각각 저장

            dic.Add(kv[0], kv[1]); // 0번은 key, 1번은 value, 사전에 각각 저장
                
        }
        
    }

    // 쓰기 종료
    public void closeWrite()
    {
        // 각각 Close
        sw.Close();
        file.Close();
    }

    // 읽기 종료
    public void closeRead()
    {
        // 각각 Close
        sr.Close();
        file.Close();
        // 사전 자료구조 재생성으로 초기화
        dic = new Dictionary<string, string>();
    }

    // 쓰기
    public void Write(string key, string value)
    {
        sw.WriteLine(key + "=" + value); // 형식대로 써넣기
    }

    /* 문제가 있어서 주석처리한 코드
    public void Read()
    {
        filename = Application.persistentDataPath + "/test" + "Save_File.txt";
        string str = string.Empty;

        if (File.Exists(filename))
        {
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            sr.Close();
            file.Close();
        }
    }
    */

    // 읽기
    public string Read(string key)
    {
        return dic[key]; // 사전에서 key를 주고 value 얻기
    }
}
