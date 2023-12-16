
// Selector
const todoInput = document.querySelector(".todo-input");
const todoButton = document.querySelector(".todo-button");
const todoList = document.querySelector(".todo-list");
const filterOption = document.querySelector(".filter-todo");
// Event Listners

document.addEventListener("DOMContentLoaded",getTodos);
document.addEventListener("DOMContentLoaded",getCompleted);


todoButton.addEventListener('click',addTodo);

todoList.addEventListener('click',deleteCheck);

filterOption.addEventListener("click",filterTodo);
// functions

function addTodo(event)
{
    // prvent form form submiting
    event.preventDefault();
    
    //To do Div

    const todoDiv = document.createElement("div");
    todoDiv.classList.add('todo');

    //create li
    const newTodo = document.createElement("li");
    newTodo.innerText =todoInput.value;
    newTodo.classList.add('todo-item');
    todoDiv.appendChild(newTodo);

    //Add to local storage

    
    //Check Mark button 

    const completeButton = document.createElement('button');
    completeButton.innerHTML = '<i class="fa-solid fa-check"></i>';
    completeButton.classList.add("complete-btn");
    todoDiv.appendChild(completeButton);

    //Check Trash Button

    const TrashButton= document.createElement('button');
    TrashButton.innerHTML = '<i class="fa-solid fa-trash"></i>';
    TrashButton.classList.add("trash-btn");
    todoDiv.appendChild(TrashButton);

    //Apend to list

    todoList.appendChild(todoDiv);
    // Clear to Do input value
    saveLocalTodos(todoInput.value);
    todoInput.value ="";
}

function deleteCheck(event)
{
    const item= event.target;

    //Delete todo

    if(item.classList[0] === 'trash-btn')
    {
        const todo = item.parentElement;
        //Animation
        todo.classList.add("fall");
        removeLocalTodo(todo);
        removeLocalComp(todo);
        todo.addEventListener('transitionend',function()
        {todo.remove();}
    )}
    //Check Martk Button
    if(item.classList[0] === 'complete-btn')
    {
        const complete= item.parentElement;
        if(complete.classList.contains('completed')){removeLocalComp(complete); saveLocalTodos(complete.innerText);}
        else{Completed(complete.innerText); removeLocalTodo(complete);}
        complete.classList.toggle('completed');
    }
}

function filterTodo(event)
{
    const todos=todoList.childNodes;
    todos.forEach(function(todo)
    {
        switch(event.target.value)
        {
            case "all":
                todo.style.display="flex";
                break;
            case "completed":
                if(todo.classList.contains("completed"))
                {todo.style.display="flex";}
                else
                {todo.style.display="none";}
                break;

            case "uncompleted":
                if(!(todo.classList.contains("completed")))
                {todo.style.display="flex";} 
                else{todo.style.display="none";}
                break;
        }
    });
}
function saveLocalTodos(todo)
{
    //Check do i already have thing in there

    let todos;
    if(localStorage.getItem("todos") === null){todos=[]}
    else{todos =JSON.parse(localStorage.getItem("todos"));}
    todos.push(todo);
    localStorage.setItem("todos",JSON.stringify(todos));
}
function getTodos()
{
    let todos;
    if(localStorage.getItem("todos") === null){todos=[]}
    else{todos =JSON.parse(localStorage.getItem("todos"));}
    todos.forEach(function(todo)
    {
           
    //To do Div

    const todoDiv = document.createElement("div");
    todoDiv.classList.add('todo');

    //create li
    const newTodo = document.createElement("li");
    newTodo.innerText =todo;
    newTodo.classList.add('todo-item');

    todoDiv.appendChild(newTodo);
    //Check Mark button 

    const completeButton = document.createElement('button');
    completeButton.innerHTML = '<i class="fa-solid fa-check"></i>';
    completeButton.classList.add("complete-btn");
    todoDiv.appendChild(completeButton);

    //Check Trash Button

    const TrashButton= document.createElement('button');
    TrashButton.innerHTML = '<i class="fa-solid fa-trash"></i>';
    TrashButton.classList.add("trash-btn");
    todoDiv.appendChild(TrashButton);

    //Apend to list

    todoList.appendChild(todoDiv);});
}
function removeLocalTodo(todo)
{
    let todos;
    if(localStorage.getItem("todos") === null){todos=[]}
    else{todos =JSON.parse(localStorage.getItem("todos"));}
    const todoIndex = todo.children[0].innerText;
    todos.splice(todos.indexOf(todoIndex),1);
    localStorage.setItem("todos",JSON.stringify(todos));
}
function Completed(complete)
{
    let comp;
    if(localStorage.getItem("comp") === null){comp=[]}
    else{comp =JSON.parse(localStorage.getItem("comp"));}
    comp.push(complete);
    localStorage.setItem("comp",JSON.stringify(comp));
}
function getCompleted()
{
    let comp;
    if(localStorage.getItem("comp") === null){comp=[]}
    else{comp =JSON.parse(localStorage.getItem("comp"));}
    comp.forEach(function(todo)
    {
           
    //To do Div

    const todoDiv = document.createElement("div");
    todoDiv.classList.add('todo');

    //create li
    const newTodo = document.createElement("li");
    newTodo.innerText =todo;
    newTodo.classList.add('todo-item');
    todoDiv.appendChild(newTodo);
    //Check Mark button 

    const completeButton = document.createElement('button');
    completeButton.innerHTML = '<i class="fa-solid fa-check"></i>';
    completeButton.classList.add("complete-btn");
    todoDiv.appendChild(completeButton);

    //Check Trash Button

    const TrashButton= document.createElement('button');
    TrashButton.innerHTML = '<i class="fa-solid fa-trash"></i>';
    TrashButton.classList.add("trash-btn");
    todoDiv.appendChild(TrashButton);
    newTodo.classList.toggle('completed');
    newTodo.parentElement.classList.toggle('completed');
    //Apend to list

    todoList.appendChild(todoDiv);});
}
function removeLocalComp(complete)
{
    let comp;
    if(localStorage.getItem("comp") === null){comp=[]}
    else{comp =JSON.parse(localStorage.getItem("comp"));}
    const todoIndex = complete.children[0].innerText;
    comp.splice(comp.indexOf(todoIndex),1);
    localStorage.setItem("comp",JSON.stringify(comp));
}
