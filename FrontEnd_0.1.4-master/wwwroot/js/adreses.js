var page = 1;
var pageSize = 15;
var totalPages;

var prevPage = document.getElementById("prevPage");
var nextPage = document.getElementById("nextPage");
var firstPage = document.getElementById("firstPage");
var lastPage = document.getElementById("lastPage");

firstPage.addEventListener("click", function () { pagination(1) });
prevPage.addEventListener("click", function () { pagination(2) });
nextPage.addEventListener("click", function () { pagination(3) });
lastPage.addEventListener("click", function () { pagination(4) });

var pageIndexBtn = document.getElementsByClassName("indexed");

for (var i = 0; i < pageIndexBtn.length; i++) {
    pageIndexBtn[i].addEventListener("click", function () {
        toPage(this.value);
    });
}

let rezultati = document.getElementById("rezultati");
let rezultatiTable = document.getElementById("rezultatiTable");
let objSkaits = document.getElementById("objSkaits");
let atlasit = document.getElementById("atlasit");

atlasit.addEventListener("click", function () {
    page = 1;
    GetAdreses(1, pageSize);
});


function GetAdreses(page, pageSize) {
    console.log("atlasit");
    let url = "https://localhost:44308" + "/DBRezultati/";

    let novads = document.getElementById("novadiID").value;

    let pagasts = document.getElementById("pagastiID").value;

    let veids = document.getElementById("veidiID").value;

    let statuss = document.getElementById("statusiID").value;

    let nosauk_dala = document.getElementById("nosauk_dala").value;

    let ID_dala = document.getElementById("adr_ID").value;

    console.log("atlasit");
    console.log("novads: ", novads);
    console.log("pagasts: ", pagasts);
    console.log("veids: ", veids);
    console.log("statuss: ", statuss);
    console.log("nosauk_dala: ", nosauk_dala);


    //loading ikona
    //let objSkaits = document.getElementById("objSkaits");
    objSkaits.innerHTML = document.getElementById("loader").innerHTML;

    //dzesham vecos ara
    rezultati.innerHTML = "";
    let xhttp = new XMLHttpRequest();

    xhttp.open("GET", url +
        "?PagastsID=" + pagasts +
        "&VeidsID=" + veids +
        "&Statuss=" + statuss +
        "&Nosauk_dala=" + nosauk_dala +
        "&NovadsID=" + novads +
        // "&VKUR_CD_NOV=" + novads +
        "&page=" + page +
        "&pageSize=" + pageSize, true);

    xhttp.send();

    xhttp.onreadystatechange = function () {
        if (this.readyState == 2) {
            //readyState == 2. send() has been called, and headers and status are available.
            // šajā posmā veicu izmaiņas

            this.responseType = "json";// atbildes tips ir JSON
            // lai nav parsing jātaisa frontendā, tas izdarīts ir backendā un frontendā pieņem to kā gatavu JSON
            //nezinu, cik daudz resursus parsing patērē, bet uzskatīju par vajadzību p
        }

        if (this.readyState == 4 && this.status == 200) {

            //objSkaits.innerHTML = "Meklēšanas statuss: " + xhttp.statusText;

            var paginationHeader = JSON.parse(this.getResponseHeader("Pagination"));

            totalPages = paginationHeader.TotalPages;
            UpdateButtons(paginationHeader);

            let results = this.response;

            // response - dod ArrayBuffer, Blob, Document, JavaScript object, DOMString atkarībā no XMLHttpRequest.responseType vērtības

            let resultsRootElement = results.rootElement;

            console.log("dataRootElement: ", results);

            if (resultsRootElement.length > 0) {

                let items = ("<thread><tr><th></th><th> Adrese </th><th> Kods </th> <th> Tips </th> <th> Statuss </th> <th> Sākuma dat. </th><th> Pēc modif.dat. </th></tr></thread>");

                for (let i = 0; i < resultsRootElement.length; i++) {

                    items += ("<tr><td> <a  href=/Adreses/Details/" + resultsRootElement[i].adR_CD + ">Skatīt</a> </td><td> " + resultsRootElement[i].std + " </td> <td> " + resultsRootElement[i].adR_CD + " </td> <td> " + resultsRootElement[i].art_KonstTips.nosaukums + " </td><td> " + resultsRootElement[i].statuss + " </td>  <td> " + resultsRootElement[i].daT_SAK + " </td><td> " + resultsRootElement[i].daT_MOD + " </td></tr>");
                }

                rezultati.innerHTML = items;
                rezultatiTable.style.display = "block";

            } else {
                console.error("Error response: ", xhttp.status);
                rezultati.innerHTML = "Nav datu \n" + xhttp.status;
            }

            objSkaits.innerHTML = "Lpp. " + page + "/" + paginationHeader.TotalPages + ", lapas izmērs " + pageSize + ", atlasīto elementu skaits " + resultsRootElement.length + ", kopējais elementu skaits " + paginationHeader.ElementCount;
            document.getElementById("pagingButtons").style.display = "block";
        }
    };
    history.pushState(null, "adresesHistory");
}

window.addEventListener('popstate', e => {
    console.log("popstate event fired");
});

function UpdateButtons(paginationHeader) {
    console.log("updating buttons");

    var btn = "ui button";
    var disBtn = "ui disabled button";

    if (paginationHeader.HasPreviousPage) {
        prevPage.className = btn;
        firstPage.className = btn;
    } else {
        prevPage.className = disBtn;
        firstPage.className = disBtn;
    }

    if (paginationHeader.HasNextPage) {
        nextPage.className = btn;
        lastPage.className = btn;
    } else {
        nextPage.className = disBtn;
        lastPage.className = disBtn;
    }
}

function toPage(index) {
    if (index > 0 && index <= totalPages) {

        page = index;
        GetAdreses(page, pageSize);

        //update button UI
        var startOfPage = index <= 2;
        var endOfPage = index >= totalPages - 1;

        if (!startOfPage && !endOfPage) {
            for (var i = 0; i < pageIndexBtn.length; i++) {
                var newIndex = index - 2 + i;
                pageIndexBtn[i].value = newIndex;
                pageIndexBtn[i].innerHTML = newIndex;
                document.getElementById(pageIndexBtn[i].id).blur();
            }
        } else if (startOfPage) {
            for (var i = 0; i < pageIndexBtn.length; i++) {
                var newIndex = i + 1;
                pageIndexBtn[i].value = newIndex;
                pageIndexBtn[i].innerHTML = newIndex;
                document.getElementById(pageIndexBtn[i].id).blur();
            }
        } else if (endOfPage) {
            for (var i = 0; i < pageIndexBtn.length; i++) {
                var newIndex = index - 4 + i;
                pageIndexBtn[i].value = newIndex;
                pageIndexBtn[i].innerHTML = newIndex;
                document.getElementById(pageIndexBtn[i].id).blur();
            }
        }
    } 
}

function pagination(dir) {
    switch (dir) {
        case 1: //firstPage
            page = 1;
            break;

        case 2: //prevPage
            page -= 1;
            break;

        case 3: //nextPage
            page += 1;
            break;

        case 4://last page
            page = totalPages;
            break;

        default:
            break;
    }
    toPage(page);
}

let novadiSelect = document.getElementById("novadiID");
novadiSelect.addEventListener("change", function () {
    let url = "https://localhost:44308/Getpagasti";

    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {

        //alert("uzspiedās " + novadiSelect.value);

        if (this.readyState == 2) {
            //readyState == 2. send() has been called, and headers and status are available.
            // šajā posmā veicu izmaiņas

            this.responseType = "json";// atbildes tips ir JSON
            // lai nav parsing jātaisa frontendā, tas izdarīts ir backendā un frontendā pieņem to kā gatavu JSON
            //nezinu, cik daudz resursus parsing patērē, bet uzskatīju par vajadzību p


        }

        if (this.readyState == 4 && this.status == 200) {

            let select = document.getElementById("pagastiID");

            while (select.firstChild) {
                select.removeChild(select.firstChild);
            }

            let items = "<option class='defaultOption' value='0'>" + "Izvēlies pagastu!" + "</option>";

            //let data = JSON.parse(this.response);

            var responseType = this.responseType;

            let data = this.response;

            // response - dod ArrayBuffer, Blob, Document, JavaScript object, DOMString atkarībā no XMLHttpRequest.responseType vērtības

            let dataRootElement = data.rootElement;

            //console.log("dataRootElement.length : " + dataRootElement.length);

            //let ter3_rnd = document.getElementById("ter3_rnd");

            let pilsetasClass = document.getElementsByClassName("pilsetasClass");

            if (dataRootElement.length > 0) {

                //ter3_rnd.style.display = "block";

                for (var i = 0; i < pilsetasClass.length; i++) {
                    pilsetasClass[i].style.display = "block";
                }

            }
            for (let i = 0; i < dataRootElement.length; i++) {
                items += "<option value='" + dataRootElement[i].adR_CD + "'>" + dataRootElement[i].std + "</option>";
            }

            select.innerHTML = items;

        } else {

            //let ter3_rnd = document.getElementById("ter3_rnd");

            //ter3_rnd.style.display = "none";

            let pilsetasClass = document.getElementsByClassName("pilsetasClass");

            for (var i = 0; i < pilsetasClass.length; i++) {
                pilsetasClass[i].style.display = "none";
            }
        }
    };

    xhttp.open("GET", url + "/NovadsID=" + novadiSelect.value, true);

    xhttp.send();
});

let pagingElCount = document.getElementById("paginationElementCount");

window.onload = function () {
    var c_pagingElCount = getCookie("paginationElementCount");
    if (c_pagingElCount != "") {
        //set select value
        setSelectValue(pagingElCount, c_pagingElCount);
    } else {
        //izveidojam cookie pēc select default val - jāuzliek lai tā ir 15
        setCookie("paginationElementCount", pagingElCount.value, 365);
    }

    pageSize = pagingElCount.value;

    let pilsetasClass = document.getElementsByClassName("pilsetasClass");

    pilsetasClass[0].style.display = "none";
    pilsetasClass[1].style.display = "none";
    document.getElementById("pagingButtons").style.display = "none";
    rezultatiTable.style.display = "none";
}

pagingElCount.addEventListener("change", function () {
    setCookie("paginationElementCount", this.value, 365);
    pageSize = this.value;
});

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 86400000));//86 400 000 ir ms skaits 1 dienā, getTime() skaita laiku milisekundes
    document.cookie = cname + "=" + cvalue + ";expires=" + d.toUTCString() + ";path=/";
}

//iegusta cookie vertibu, ja tas eksiste, ja ne - atgriez tuksu string
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

//sel - <select> elements, value - vertiba, kura sakrit ar attiecigu <option> vertibu
//ja atradis tadu <option> tas tiks selectots
function setSelectValue(sel, value) {
    var options = sel.options;
    for (var opt, j = 0; opt = options[j]; j++) {
        if (opt.value == value) {
            sel.selectedIndex = j;
            break;
        }
    }
}

document.getElementById("attir").addEventListener("click", function () {
    let defaultOption = document.getElementsByClassName("defaultOption");

    let i;

    for (i = 0; i < defaultOption.length; i++) {
        defaultOption.item(i).selected = true;
    }

    document.getElementById("nosauk_dala").value = "";

    document.getElementById("adr_ID").value = "";

    rezultati.innerHTML = "";
    objSkaits.innerHTML = "";

    document.getElementById("pagingButtons").style.display = "none";
    rezultatiTable.style.display = "none";
});

//semantic ui stuff jquery
$('select.dropdown')
    .dropdown()
    
$('.ui.dropdown')
    .dropdown();
