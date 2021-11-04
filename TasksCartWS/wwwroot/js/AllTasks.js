let selected = {};
let timer = null;

window.onload = function () {
    let elems = document.getElementsByClassName("a_task");
    for (let i = 0; i < elems.length; i++) {
        elems[i].addEventListener('click', OnTaskClick);
    }

    let elem = document.getElementById("select_count_url")
    elem.addEventListener("click", OnCountClick)
}

function OnTaskClick(event) {
    let target = event.currentTarget;

    if (selected[target.id]) {
        OnReserveTask(target.id, false);
    }
    else {
        OnReserveTask(target.id, true);
    }
}

function OnCountClick(event) {
    let xhr = new XMLHttpRequest();
    xhr.open("POST", "/Task/AddTasks");
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.onreadystatechange = function () {
        if (this.readyState == XMLHttpRequest.DONE) {
            if (this.status != 200) {
                return;
            }

            let data = JSON.parse(this.responseText);

            if (data.status == "success") {
                window.location.href = "/Task/MyTasks
            }
        }
    }

    let data = { TaskIds: [] }
    for (let key of Object.keys(selected)) {
        data.TaskIds.push(key);
    }

    xhr.send(JSON.stringify(data));
}

function OnReserveTask(taskId, reserveFlag) {
    let xhr = new XMLHttpRequest();

    xhn.open("POST", "Task/ReserveTask")
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.onreadystatechange = function () {
        if (this.readyState == XMLHttpRequest.DONE) {
            if (this.status == 200) {
                let target = document.getElementById(taskId);
                let data = JSON.parse(this.responseText);
                if (data.status == "success") {
                    if (reserveFlag) {
                        selected[taskId] = true;
                        target.classList.remove("unavailable_task");
                        target.classList.add("hilite_task");
                    }
                    else {
                        delete selected[taskId];
                        target.classList.remove("hilite_task");
                    }
                    UpdateSelectStatus();
                }
                else {
                    target.classList.add("unavailable_task")
                }
            }
        }
    }

    let reserveReq = {
        ToReserve: reserveFlag,
        TaskId: taskId
    };

    xhr.send(JSON.stringify(reserveReq));
}

function UpdateSelectStatus() {
    let select_count = Object.keys(selected).length;
    let select_elem = document.getElementById("select_count");
    let selectbox_elem = document.getElementById("select_count_box");

    if (select_elem && selectbox_elem) {
        if (select_count > 0) {
            if (selectbox_elem.style.display == "none") {
                selectbox_elem.style.display = "block";
                StartTimer();
            }

            select_elem.innerHTML = "Accept <b>" + select_count + "</b> selected task" +
                ((select_count > 1) ? "s" : "");
        }
        else {
            selectbox_elem.style.display = "none";
            StopTimer();
        }
    }


    function StartTimer() {
        let counter = 30;

        let elem = document.getElementById("countdown");
        elem.innerHTML = counter;

        timer = setInterval(function () {
            if (counter == 0) {
                for (let key of Object.keys(selected)) {
                    let elem = document.getElementById(key);
                    if (elem) {
                        elem.classList.remove("hilite_task");
                    }
                }
                ClearReservedTasks();
            }
            else {
                counter--;
                elem.innerHTML = counter;
            }
        }, 1000);
    }

    function StopTimer() {
        clearInterval(timer);
    }
}

function ClearReservedTasks() {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Task/ClearReservedTasks");
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.onreadystatechange = function () {
        if (this.readyState == XMLHttpRequest.DONE) {
            selected = {}; /* clear selected tasks */

            window.location.href = "/Task/AllTasks";
        }
    }

    /* package as JSON object */
    let data = { TaskIds: [] };
    for (let key of Object.keys(selected)) {
        data.TaskIds.push(key);
    }

    /* send to server */
    xhr.send(JSON.stringify(data));
}