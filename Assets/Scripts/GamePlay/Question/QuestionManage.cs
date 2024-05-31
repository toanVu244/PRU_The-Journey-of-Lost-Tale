using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

[SerializeField]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}
public class QuestionManage : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public TextMeshProUGUI feedbackText;

    private List<Question> remainingQuestions = new List<Question>();
    private Question currentQuestion;
    private int countTrue;

    void Start()
    {
        CreateQuestions();
        DisplayNextQuestion();
    }
    
    void CreateQuestions()
    {
        Question question1 = new Question();
        question1.questionText = "Thứ gì khác với 3 thứ còn lại?";
        question1.answers = new string[] { "Lá cây", "Cây", "Cành cây", "Thân cây" };
        question1.correctAnswerIndex = 0;
        remainingQuestions.Add(question1);

        Question question2 = new Question();
        question2.questionText = "Thứ gì khác với 3 thứ còn lại?";
        question2.answers = new string[] { "Chó", "Hổ", "Mèo", "Sư tử" };
        question2.correctAnswerIndex = 0;
        remainingQuestions.Add(question2);

        Question question3 = new Question();
        question3.questionText = "Thứ gì khác với 3 thứ còn lại?";
        question3.answers = new string[] { "Vũ trụ", "Mặt trời", "Trái đất", "Mặt trăng" };
        question3.correctAnswerIndex = 0;
        remainingQuestions.Add(question3);

        Question question4 = new Question();
        question4.questionText = "Thứ gì khác với 3 thứ còn lại?";
        question4.answers = new string[] { "Gừng", "Cà rốt", "Khoai tây", "Cà chua" };
        question4.correctAnswerIndex = 2;
        remainingQuestions.Add(question4);

        Question question5 = new Question();
        question5.questionText = "Thứ gì khác với 3 thứ còn lại?";
        question5.answers = new string[] { "Hình lập phương", "Hình chữ nhật", "Hình vuông", "Hình tam giác" };
        question5.correctAnswerIndex = 0;
        remainingQuestions.Add(question5);

        Question question6 = new Question();
        question6.questionText = "Thứ gì khác với 3 thứ còn lại?";
        question6.answers = new string[] { "Ngôi nhà", "Bức tường", "Tầng hầm", "Mái nhà" };
        question6.correctAnswerIndex = 0;
        remainingQuestions.Add(question6);

        Question question7 = new Question();
        question7.questionText = "Hiệp khí đạo là tên khác của môn võ nào?";
        question7.answers = new string[] { "Aikido", "Judo", "Karate", "Vovinam" };
        question7.correctAnswerIndex = 0;
        remainingQuestions.Add(question7);

        Question question8 = new Question();
        question8.questionText = "Lễ hội khai ấn Đền Trần diễn ra ở tỉnh nào?";
        question8.answers = new string[] { "Ninh Bình", "Bắc Ninh", "Nam Định", "Bình Định" };
        question8.correctAnswerIndex = 2;
        remainingQuestions.Add(question8);

        Question question9 = new Question();
        question9.questionText = "Đàn cổ cầm có mấy dây?";
        question9.answers = new string[] { "5", "6", "7","8" };
        question9.correctAnswerIndex = 2;
        remainingQuestions.Add(question9);

        Question question10 = new Question();
        question10.questionText = "Sông nào ngăn cách thời kỳ Đàng Trong và Đàng Ngoài?";
        question10.answers = new string[] { "Sông Gâm", "Sông Tranh", "Sông Gianh", "Sông Đồng Nai" };
        question10.correctAnswerIndex = 2;
        remainingQuestions.Add(question10);

        Question question11 = new Question();
        question11.questionText = "Tác phẩm nào của nhà văn Hemingway đã đoạt giải Nobel văn học năm 1954?";
        question11.answers = new string[] { "Ông già và biển cả", "Giã từ vũ khí", "Chuông nguyện hồn ai", "Tuyết trên đỉnh Kilimanjaro" };
        question11.correctAnswerIndex = 0;
        remainingQuestions.Add(question11);

        Question question12 = new Question();
        question12.questionText = "Quá trình sinh tổng hợp protein diễn ra ở bộ phận nào trong tế bào?";
        question12.answers = new string[] { "Ti thể", "Ribosome", "Lưới nội chất", "Bộ máy Golgi" };
        question12.correctAnswerIndex = 1;
        remainingQuestions.Add(question12);

        Question question13 = new Question();
        question13.questionText = "Thao, Nho, Phương, Định là những nhân vật trong tác phẩm nào của nhà văn Lê Minh Khuê?";
        question13.answers = new string[] { "Những ngôi sao xa xôi", "Mây giăng cuối phố", "Đất bỏ hoang", "Tiếng lòng" };
        question13.correctAnswerIndex = 0;
        remainingQuestions.Add(question13);

        Question question14 = new Question();
        question14.questionText = "Do đâu Nguyễn Ái Quốc đã triệu tập và chủ trì Hội nghị thành lập Đảng đầu năm 1930?";
        question14.answers = new string[] { "Được sự uỷ nhiệm của Quốc tế Cộng sản", "Nhận được chỉ thị của Quốc tế Cộng sản", "Sự chủ động của Nguyễn Ái Quốc", "Các tổ chức cộng sản trong nước đề nghị" };
        question14.correctAnswerIndex = 2;
        remainingQuestions.Add(question14);

        Question question15 = new Question();
        question15.questionText = "Trong một số thức ăn dưới đây, thức ăn nào không chứa chất bột đường?";
        question15.answers = new string[] { "Khoai lang", "Gạo", "Ngô", "Tôm" };
        question15.correctAnswerIndex = 3;
        remainingQuestions.Add(question15);

        Question question16 = new Question();
        question16.questionText = "Âm thanh do đâu phát ra?";
        question16.answers = new string[] { "Do các vật va đập với nhau", "Do các vật rung động", "Do uốn cong các vật", "Do nén các vật" };
        question16.correctAnswerIndex = 1;
        remainingQuestions.Add(question16);

        Question question17 = new Question();
        question17.questionText = "Nguyên nhân gây bệnh bướu cổ?";
        question17.answers = new string[] { "Vì ăn nhiều chất đạm", "Vì ăn nhiều chất béo", "Vì ăn nhiều đường", "Vì không ăn muối I-ốt" };
        question17.correctAnswerIndex = 3;
        remainingQuestions.Add(question17);

        Question question18 = new Question();
        question18.questionText = "Vai trò chính của chất đạm là:";
        question18.answers = new string[] { "Cung cấp năng lượng cho cơ thể", "Duy trì nhiệt độ cho cơ thể", "Xây dựng và đổi mới cơ thể: tái tạo những tế bào mới làm cơ thể lớn lên" , "Giúp cơ thể hấp thụ nước" };
        question18.correctAnswerIndex = 2;
        remainingQuestions.Add(question18);

        Question question19 = new Question();
        question19.questionText = "Vai trò chính của chất béo là:";
        question19.answers = new string[] { "Cung cấp năng lượng cho cơ thể", "Duy trì nhiệt độ cho cơ thể", "Xây dựng và đổi mới cơ thể: tái tạo những tế bào mới làm cơ thể lớn lên", "Giúp cơ thể hấp thụ vitamin" };
        question19.correctAnswerIndex = 3;
        remainingQuestions.Add(question19);

        Question question20 = new Question();
        question20.questionText = "Trong tiếng Việt, có bao nhiêu thanh điệu?";
        question20.answers = new string[] { "5", "6", "7", "8" };
        question20.correctAnswerIndex = 1;
        remainingQuestions.Add(question20);

        Question question21 = new Question();
        question21.questionText = "Tác phẩm 'Ếch ngồi đáy giếng' thuộc thể loại truyện gì?";
        question21.answers = new string[] { "Cười", "Cổ tích", "Truyền thuyết", "Ngụ ngôn" };
        question21.correctAnswerIndex = 3;
        remainingQuestions.Add(question21);
    }

    void DisplayNextQuestion()
    {
        feedbackText.gameObject.SetActive(false);
        if (remainingQuestions.Count == 0)
        {
            if (countTrue < 10)
            {
                feedbackText.text = "You've completed all the questions! \nYou have been defeated! Total Correct anwer:" + countTrue;
                feedbackText.gameObject.SetActive(true);
                return;
            }
            else
            {
                feedbackText.text = "You've completed all the questions! \nYou Win! Total Correct anwer:" + countTrue;
                feedbackText.gameObject.SetActive(true);
                return;
            }
        }
        int randomIndex = Random.Range(0, remainingQuestions.Count);
        currentQuestion = remainingQuestions[randomIndex];

        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];
            answerButtons[i].onClick.RemoveAllListeners();
            int index = i; 
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));           
        }
        remainingQuestions.RemoveAt(randomIndex);
    }

    void CheckAnswer(int index)
    {
        if (index == currentQuestion.correctAnswerIndex)
        {
            feedbackText.text = "Correct!";
            countTrue++;
        }
        else
        {
            feedbackText.text = "Wrong!";        
        }
        feedbackText.gameObject.SetActive(true);
        Invoke("DisplayNextQuestion", 1f);
    }
}
