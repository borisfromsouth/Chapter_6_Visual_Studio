document.addEventListener("DOMContentLoaded", function () {
    var element = document.createElement("p");
    element.textContent = "This is element from the fourth (modify) js file";
    document.querySelector("body").appendChild(element);  // находит первый элемент с именем "body" и добавляет узел element в конец(!!!) списка элементов
});