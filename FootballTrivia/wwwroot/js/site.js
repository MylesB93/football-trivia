var questions = window.questions;
var currentQuestion = 0;

document.getElementById('question').innerHTML = questions[currentQuestion][0]
document.getElementById('answer').innerHTML = questions[currentQuestion][1]

var correctAnswer = questions[currentQuestion][1][0]
var answers = questions[currentQuestion][1]
var randomisedAnswers = answers.sort(() => Math.random() - 0.5)

document.getElementById('answer-0').innerHTML = randomisedAnswers[0]
document.getElementById('answer-1').innerHTML = randomisedAnswers[1]
document.getElementById('answer-2').innerHTML = randomisedAnswers[2]

function checkAnswer(element) {
	console.log(element.innerHTML)
	var answer = element.innerHTML
	if (answer == correctAnswer) {
		alert("CORRECT!!!!!")
	} else {
		alert("INCORRECT!!!!!")
	}
}