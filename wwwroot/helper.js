var GLOBAL = {};
var notificationSound;
GLOBAL.DotNetReference = null;
GLOBAL.MainDotNetReference = null;
GLOBAL.SetDotnetReference = function (pDotNetReference) {
    GLOBAL.DotNetReference = pDotNetReference;
};
GLOBAL.SetMainDotnetReference = function (pDotNetReference) {
    GLOBAL.MainDotNetReference = pDotNetReference;
};

window.Delivery3Theme = {
    Init: function () {
        KTApp.init();
        KTMenu.init();
    }
}

window.Modal = {
    Close: function (modal) {
        $("#" + modal).modal("hide");
    },
    Show: function (modal) {
        $("#" + modal).modal("show");
    },
}

window.InputMask = {
    Money: function () {
        $('.money').mask('#.##0,00', {reverse: true});
    },
    Zipcode: function () {
        $(".zipcode").mask("99999-999");
    },
    Number: function () {
        $(".number").mask("999999999");
    },
    Phone: function () {
        $(".phone").mask("(99) 99999-9999");
    },
    Document: function () {
        $(".document").mask("999.999.999-99");
    },    
    Password: function () {
        KTPasswordMeter.createInstances();
        
        var options = {
            minLength: 8,
            checkUppercase: true,
            checkLowercase: true,
            checkDigit: true,
            checkChar: true,
            scoreHighlightClass: "active"
        };
        var passwordMeterElement = document.querySelector("#kt_password_meter_control");
        var passwordMeter = new KTPasswordMeter(passwordMeterElement, options);
    }
}

window.DatePicker = {
    Order: function (field, callback) {
        flatpickr($(field), {
            enableTime: false,
            noCalendar: false,
            dateFormat: "d/m/Y",
            locale: "pt",
            onChange: function (date, dateStr, e) {
                GLOBAL.DotNetReference.invokeMethodAsync(callback, {
                    Input: e.element.name,
                    DateStr: dateStr
                });
            }
        });
    },
    OrderCreate: function (field, callback) {
        flatpickr($(field), {
            enableTime: false,
            noCalendar: false,
            inline: true,
            position: "auto center",
            defaultDate: "today",
            dateFormat: "d/m/Y",
            locale: "pt",
            onChange: function (date, dateStr, e) {
                GLOBAL.DotNetReference.invokeMethodAsync(callback, {
                    Input: e.element.name,
                    DateStr: dateStr
                });
            }
        });
    },
    Financial: function (field) {
        flatpickr($(field), {
            plugins: [
                monthSelectPlugin({
                    shorthand: false,
                    longhand: true,
                    altInput: true,
                    altFormat: "F, \\de Y",
                    dateFormat: "F, \\de Y",
                    theme: "light",
                })
            ],
            enableTime: false,
            noCalendar: false,
            altInput: false,
            altFormat: "F, \\de Y",
            dateFormat: "Y-m-d",
            locale: "pt",
            maxDate: "today",
            defaultDate: "today",
            position: "auto center",
            onChange: function (date, dateStr, e) {
                GLOBAL.DotNetReference.invokeMethodAsync('SetDateFilterFromDatePicker', {
                    Input: e.element.name,
                    DateStr: dateStr
                });
            }
        });
    },
}

window.OnModalShow = {
    Focus: function (modal, field) {
        $("#" + modal).on('show.bs.modal', function (e) {
            setTimeout(function () {
                $("input[name=" + field + "]").focus();
            }, 500);
        })
    },
    Select: function (modal, field) {
        $("#" + modal).on('show.bs.modal', function (e) {
            setTimeout(function () {
                $("input[name=" + field + "]").select();
            }, 500);
        })
    }
}

window.Clipboard = {
    Init: function (element) {
        var target = document.getElementById(element);
        var button = target.nextElementSibling;

        var clipboard = new ClipboardJS(button, {
            target: target,
            text: function () {
                navigator.clipboard.writeText(target.value);
                return target.value;
            }
        });

        clipboard.on('success', function (e) {
            const currentLabel = button.innerHTML;
            if (button.innerHTML === 'Copiado!') {
                return;
            }
            button.innerHTML = 'Copiado!';
            setTimeout(function () {
                button.innerHTML = currentLabel;
            }, 3000)
        });
    }
}

window.ElementInvoke = {
    Click: function (element) {
        $("#" + element)[0].click();
    },
    Text: function (element) {
        return $(element)[0].title;
    },
    Scroll: function (element) {
        var el = document.getElementById(element)
        if (el) {
            el.scrollIntoView({behavior: "smooth"});
        }

        return false;
    }
}

window.Toastr = {
    Success: function (msg) {
        toastr.success(msg);
    },
    Info: function (msg) {
        toastr.info(msg);
    },
    Error: function (msg) {
        toastr.error(msg);
    },
    Warning: function (msg) {
        toastr.warning(msg);
    }
}

window.Audio = {
    Init: function () {
        notificationSound = new Howl({
            src: ['https://delivery3-dzgdgkbdccbefha5.z03.azurefd.net/portal/audios/telephone.mp3']
        });
    },
    Play: function () {
        notificationSound.play();
    },
    Stop: function () {
        notificationSound.stop();
    }
}

window.Callback = {
    WorkflowOrder: function (store) {
        GLOBAL.MainDotNetReference.invokeMethodAsync('RefreshOrder', {Store: store});
    }
}

window.Draggable2 = {
    Init: function () {
        var containers = document.querySelectorAll(".draggable-zone");

        if (containers.length === 0) {
            return false;
        }

        var swappable = new Sortable.default(containers, {
            draggable: ".draggable",
            handle: ".draggable .draggable-handle",
            mirror: {
                appendTo: "body",
                constrainDimensions: true
            }
        });

        swappable.on('drag:stop', (evt) => {
            GLOBAL.DotNetReference.invokeMethodAsync('UpdateSortAsync');
        });
    },
    GetSort: function () {
        var items = [];
        $(".card.draggable").each(function (i, item) {
            items.push(Number(item.id))
        })
        return items;
    }
}

window.ChartJs = {
    LineChart: function (scores, categories) {
        var a = "300"
        var l = "#000";
        var r = "#d1d1d1";
        var o = "#129fa5";
        var apex = new ApexCharts(document.getElementById("kt_charts_widget_28"), {
            series: [{
                style: {fontFamily: "Inter,Helvetica,sans-serif"},
                name: "Valor",
                data: scores
            }],
            chart: {fontFamily: "Inter,Helvetica,sans-serif", type: "area", height: a, toolbar: {show: !1}},
            legend: {show: true, style: {fontFamily: "Inter,Helvetica,sans-serif"}},
            dataLabels: {enabled: false, style: {fontFamily: "Inter,Helvetica,sans-serif"}},
            fill: {
                type: "gradient",
                gradient: {shadeIntensity: 1, opacityFrom: 1, opacityTo: 1, stops: [0, 80, 100]}
            },
            stroke: {curve: "smooth", show: !0, width: 3, colors: [o]},
            xaxis: {
                categories: categories,
                axisBorder: {show: !1},
                offsetX: 20,
                axisTicks: {show: !1},
                tickAmount: 3,
                labels: {
                    rotate: 0,
                    rotateAlways: !1,
                    style: {colors: l, fontSize: "12px", fontFamily: "Inter,Helvetica,sans-serif"}
                },
                crosshairs: {position: "front", stroke: {color: o, width: 1, dashArray: 3}},
                tooltip: {
                    enabled: !1,
                    formatter: void 0,
                    offsetY: 0,
                    style: {fontSize: "12px", fontFamily: "Inter,Helvetica,sans-serif"}
                },
            },
            yaxis: {
                tickAmount: 4,
                labels: {
                    style: {colors: l, fontSize: "12px", fontFamily: "Inter,Helvetica,sans-serif"},
                    formatter: function (e) {
                        return "R$ " + e;
                    },
                },
            },
            states: {
                normal: {filter: {type: "none", value: 0}},
                hover: {filter: {type: "none", value: 0}},
                active: {allowMultipleDataPointsSelection: !1, filter: {type: "none", value: 0}}
            },
            tooltip: {
                style: {fontSize: "12px", fontFamily: "Inter,Helvetica,sans-serif;"},
                y: {
                    formatter: function (e) {
                        return "R$ " + Number(e).toFixed(2).replace(".", ",");
                    },
                },
            },
            colors: [o],
            grid: {borderColor: r, strokeDashArray: 4, yaxis: {lines: {show: !0}}},
            markers: {strokeColor: o, strokeWidth: 3},
        });
        apex.render();
    },
    PineChart: function (values, categories) {
        var t = document.getElementById("kt_pine_chart");
        var e = t.getContext("2d");
        new Chart(e, {
            type: "pie",
            data: {
                datasets: [{
                    data: values,
                    backgroundColor: ["#00FF00", "#FF0000", "#00b2ff", "#FF00FF", "#8A2BE2", "#FFFF00", "#D2691E"]
                }], labels: ["Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo"]
            },
            options: {
                chart: {fontFamily: "inherit"},
                borderWidth: 0,
                cutout: "75%",
                cutoutPercentage: 65,
                responsive: !0,
                maintainAspectRatio: !1,
                title: {display: !1},
                animation: {animateScale: !0, animateRotate: !0},
                stroke: {width: 0},
                tooltips: {
                    enabled: !1,
                    intersect: !1,
                    mode: "nearest",
                    bodySpacing: 5,
                    yPadding: 10,
                    xPadding: 10,
                    caretPadding: 0,
                    displayColors: !1,
                    backgroundColor: "#20D489",
                    titleFontColor: "#ffffff",
                    cornerRadius: 4,
                    footerSpacing: 0,
                    titleSpacing: 0,
                },
                plugins: {legend: {display: !1}},
            },
        });
    },
};

window.TwoFactor = {
    Init: function () {
        var n, i, o, u, r, c;
        t = document.querySelector("#kt_sing_in_two_factor_form"), (e = document.querySelector("#kt_sing_in_two_factor_submit")).addEventListener("click", (function (n) {
            n.preventDefault();
            var i = !0,
                o = [].slice.call(t.querySelectorAll('input[maxlength="1"]'));
            o.map((function (t) {
                "" !== t.value && 0 !== t.value.length || (i = !1)
            })), !0 === i ? (e.setAttribute("data-kt-indicator", "on"), e.disabled = !0, setTimeout((function () {
                e.removeAttribute("data-kt-indicator"), e.disabled = !1, Swal.fire({
                    text: "You have been successfully verified!",
                    icon: "success",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok, got it!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                }).then((function (e) {
                    if (e.isConfirmed) {
                        o.map((function (t) {
                            t.value = ""
                        }));
                        var n = t.getAttribute("data-kt-redirect-url");
                        n && (location.href = n)
                    }
                }))
            }), 1e3)) : swal.fire({
                text: "Please enter valid securtiy code and try again.",
                icon: "error",
                buttonsStyling: !1,
                confirmButtonText: "Ok, got it!",
                customClass: {
                    confirmButton: "btn fw-bold btn-light-primary"
                }
            }).then((function () {
                KTUtil.scrollTop()
            }))
        })), n = t.querySelector("[name=code_1]"), i = t.querySelector("[name=code_2]"), o = t.querySelector("[name=code_3]"), u = t.querySelector("[name=code_4]"), r = t.querySelector("[name=code_5]"), c = t.querySelector("[name=code_6]"), n.focus(), n.addEventListener("keyup", (function () {
            1 === this.value.length && i.focus()
        })), i.addEventListener("keyup", (function () {
            1 === this.value.length && o.focus()
        })), o.addEventListener("keyup", (function () {
            1 === this.value.length && u.focus()
        })), u.addEventListener("keyup", (function () {
            1 === this.value.length && r.focus()
        })), r.addEventListener("keyup", (function () {
            1 === this.value.length && c.focus()
        })), c.addEventListener("keyup", (function () {
            1 === this.value.length && c.blur()
        }))
    }
}

const _getMask = function (input_value, event, element, options) {
    const numbers = input_value.replace(/\D+/g, '');
    return numbers.length <= 11 ? '000.000.000-000' : '00.000.000/0000-00';
}

toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": true,
    "progressBar": false,
    "positionClass": "toastr-bottom-right",
    "preventDuplicates": true,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};
