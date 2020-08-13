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

let pagasti = document.getElementById("pagastiID")
pagasti.addEventListener("change", function () {
    let url = "/Home/Excel?novadsID=" + novadiSelect.value + "&pagastsID=" + pagasti.value;
    document.getElementById("atlasitNL").href = url;
});

document.getElementById("attir").addEventListener("click", function () {
    let defaultOption = document.getElementsByClassName("defaultOption");

    for (let i = 0; i < defaultOption.length; i++) {
        defaultOption.item(i).selected = true;
    }
});