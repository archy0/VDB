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

let objSkaits = document.getElementById("objSkaits");

let atlasitDok = document.getElementById("atlasitDok");


atlasitDok.addEventListener("click", function () {
    page = 1;
    GetDokumenti(1, pageSize)
});

function GetDokumenti(page, pageSize) {
    let pagastsID = document.getElementById("pagastiID").value;
    let rezultati = document.getElementById("rezultati");

    let url = "https://localhost:44308/Dokumenti/DokumentiById" + "?page=" + page + "&pageSize=" + pageSize;;

    //dzesham vecos ara
    rezultati.innerHTML = "";

    //loading ikona
    objSkaits.innerHTML = document.getElementById("loader").innerHTML;

    let xhttp = new XMLHttpRequest();

    xhttp.open("GET", url, true);

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

            var paginationHeader = JSON.parse(this.getResponseHeader("Pagination"));
            console.log(paginationHeader);

            totalPages = paginationHeader.TotalPages;

            UpdateButtons(paginationHeader);

            let results = this.response;

            // response - dod ArrayBuffer, Blob, Document, JavaScript object, DOMString atkarībā no XMLHttpRequest.responseType vērtības

            let resultsRootElement = results.rootElement;


            if (resultsRootElement.length > 0) {

                let items = "<thread><tr><td></td><td>Izdošanas datums</td><td>Iestāde-dokumenta izdevēja</td><td>Dokumenta nosaukums</td></tr></thread>";

                for (let i = 0; i < resultsRootElement.length; i++) {

                    items += ("<tr><td><a href=https://localhost:44308/Dokumenti/Detalas?id=" + resultsRootElement[i].id + ">Skatīt</a></td><td>" + resultsRootElement[i].datums + "</td><td>" + resultsRootElement[i].organiZ_ID + "</td><td>" + resultsRootElement[i].nosaukums + "</td></tr>");
                }

                rezultati.innerHTML = items;

            } else {
                console.error("Error response: ", xhttp.status);
                rezultati.innerHTML = "Nav datu \n" + xhttp.status;
            }

            objSkaits.innerHTML = "Lpp. " + page + "/" + paginationHeader.TotalPages + ", lapas izmērs " + pageSize + ", atlasīto elementu skaits " + resultsRootElement.length + ", kopējais elementu skaits " + paginationHeader.ElementCount;
            document.getElementById("pagingButtons").style.display = "block";

        } 
    };
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

document.getElementById("attir").addEventListener("click", function () {
    let defaultOption = document.getElementsByClassName("defaultOption");

    for (let i = 0; i < defaultOption.length; i++) {
        defaultOption.item(i).selected = true;
    }

    document.getElementById("rezultati").innerHTML = "";
    document.getElementById("objSkaits").innerHTML = "Topošie atlases rezultāti...";
});

window.onload = function () {
    document.getElementById("pagingButtons").style.display = "none";
}

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

function pagination(dir) {
    switch (dir) {
        case 1: //firstPage
            page = 1;
            GetDokumenti(1, pageSize);
            break;

        case 2: //prevPage
            page -= 1;
            GetDokumenti(page, pageSize);
            break;

        case 3: //nextPage
            page += 1;
            GetDokumenti(page, pageSize)
            break;

        case 4://last page
            page = totalPages;
            GetDokumenti(totalPages, pageSize);
            break;

        default:
            break;
    }
}