const dropdownHandler = () => {
    const dropdown = document.querySelector(".regular-dropdown");

    if (dropdown != null) {
        dropdown.addEventListener("click", () => {
            const dropdownOption = document.querySelector(".regular-dropdown .option");
            if (dropdownOption.classList.contains("dropdown-open")) dropdownOption.classList.remove("dropdown-open")
            else dropdownOption.classList.add("dropdown-open")
        })
    }
}

const resourceCodeUpsertFormPopupOpenHandler = () => {
    const updateButton = document.querySelector(".resource-upsert-form .add-new-button")

    if (updateButton != null) {
        updateButton.addEventListener("click", () => {
            const popupContainer = document.querySelector(".popup-container")
            const resourceCodeUpsertFormPopup = document.querySelector(".resource-code-upsert-form-popup")
            popupContainer.classList.add("popup-container-open")
            resourceCodeUpsertFormPopup.classList.add("resource-code-upsert-form-popup-open")
        })
    }
}

const resourceCodeUpsertFormSubmitHandler = () => {
    const submitButton = document.querySelector(".resource-code-upsert-form-popup .submit-button")

    if (submitButton != null) {
        submitButton.addEventListener("click", () => {
            const code = document.querySelector(".resource-code-upsert-form-popup #code").value
            const resourceId = document.querySelector(".resource-upsert-form .resource-id").value
            const status = document.querySelector(".resource-code-upsert-form-popup #status")
            const resourceCodeTableBody = document.querySelector(".resource-code-list tbody")
            const resourceCodeTableBodyLength = resourceCodeTableBody.children.length

            const newItem = {
                code: code,
                resourceid: parseInt(resourceId),
                status: status.checked
            }

            const newItemStatus = newItem.status == true ?
                `<input type="checkbox" disabled checked />`
                :
                `<input type="checkbox" disabled />`

            resourceCodeTableBody.innerHTML +=
                `<tr>
                <input type="hidden" name="ResourceCodes[${resourceCodeTableBodyLength}].Code" value=${newItem.code} />
                <input type="hidden" name="ResourceCodes[${resourceCodeTableBodyLength}].ResourceId" value=${newItem.resourceid} />
                <td>
                    <input type="hidden" name="ResourceCodes[${resourceCodeTableBodyLength}].Status" value=${newItem.status} />
                    ${newItemStatus}
                </td>
                <td>${newItem.code}</td>
            </tr>`

            popupClose()
        })
    }
}

const popupCloseHandler = () => {
    const closeButton = document.querySelector(".form-popup .close-popup-button")

    if (closeButton != null) {
        closeButton.addEventListener("click", () => {
            popupClose()
        })
    }
}

const popupClose = () => {
    const popupContainer = document.querySelector(".popup-container")
    const resourceCodeUpsertFormPopup = document.querySelector(".resource-code-upsert-form-popup")
    const formPopupInputs = document.querySelectorAll(".form-popup input")
    popupContainer.classList.remove("popup-container-open")
    resourceCodeUpsertFormPopup.classList.remove("resource-code-upsert-form-popup-open")

    if (formPopupInputs != null) {
        formPopupInputs.forEach(formPopupInput => {
            if (formPopupInput.type === 'checkbox' || formPopupInput.type === 'radio') {
                formPopupInput.checked = false
            } else {
                formPopupInput.value = ''
            }
        })
    }
}

const fileDetailUpdateOnChange = () => {
    const fileInput = document.querySelector("#file")

    if (fileInput != null) {
        fileInput.addEventListener("change", function (event) {
            const file = event.target.files[0]
            const fileReader = new FileReader()

            fileReader.onload = function (event) {
                console.log(event.target.result)
                const fileGroup = document.querySelector(".file-group")
                const filePath = document.querySelector(".file-group .file-path")
                const newImage = `<img src=${event.target.result}" />`
                if (fileGroup.querySelector("img") == null) fileGroup.insertBefore(newImage, fileGroup.firstChild)
                else {
                    const fileImage = document.querySelector(".file-group img")
                    fileImage.src = `${event.target.result}`
                }

                filePath.innerHTML = file.name
            }

            fileReader.readAsDataURL(file)
        })
    }
}

dropdownHandler()
resourceCodeUpsertFormPopupOpenHandler()
resourceCodeUpsertFormSubmitHandler()
popupCloseHandler()
fileDetailUpdateOnChange()
