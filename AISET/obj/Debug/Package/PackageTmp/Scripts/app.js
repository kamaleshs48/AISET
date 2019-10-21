﻿angular.module('app', [])
    .directive('myContact', function () {
        return {
            scope: {},
            templateUrl: 'contact.html',
            controller: "contactCtrl"
        }
    })
    .directive('myquickContact', function () {
        return {
            scope: {},
            templateUrl: 'quickcontact.html',
            controller: "contactCtrl"
        }
    })
    .directive('myquickDownload', function () {
        return {
            scope: {},
            templateUrl: 'quickDownload.html',
            controller: "contactCtrl"
        }
    })
    .directive('signupContact', function () {
        return {
            scope: {},
            templateUrl: 'signupcontact.html',
            controller: "contactCtrl"
        }
    }).directive('modalContact', function () {
        return {
            // scope: {},
            templateUrl: 'modalcontact.html',
            controller: "contactCtrl"
        }
    }).directive("dtCompare", function () {
        return {
            require: "ngModel",
            link: function (scope, currentEl, attrs, ctrl) {
                var firstFl = document.getElementsByName(attrs.dtCompare)[0];
                var firstEl = angular.element(firstFl);

                currentEl.on("keyup", function () {
                    var IsMatch = firstEl.val() === currentEl.val();
                    ctrl.$setValidity("compare", IsMatch);
                    scope.$digest();
                });
                firstEl.on("keyup", function () {
                    var IsMatch = firstEl.val() === currentEl.val();
                    ctrl.$setValidity("compare", IsMatch);
                    scope.$digest();
                })
            }
        }
    })
    .controller('contactCtrl', ['$scope', function ($scope) {
        $scope.countryData = {
            repeatSelect: '+91-',
            availableOptions: [
               { CountryValue: '+91-', CountryCode: 'IN - India' },
               { CountryValue: '+1-', CountryCode: 'US  -  United States' },
               { CountryValue: '+61-', CountryCode: 'AU  -  Australia' },
               { CountryValue: '+44-', CountryCode: 'GB  -  United Kingdom' },
               { CountryValue: '+91-', CountryCode: 'IN - India' },
               { CountryValue: '+966-', CountryCode: 'SA  -  Saudi Arabia' },
               { CountryValue: '+971-', CountryCode: 'AE  -  United Arab Emirates' },
               { CountryValue: '+1-', CountryCode: 'CA  -  Canada' },
               { CountryValue: '+65-', CountryCode: 'SG  -  Singapore' },
               { CountryValue: 'disabled', CountryCode: '-----------------------------------------' },
               { CountryValue: '+41-', CountryCode: 'CH  -  Switzerland' },
               { CountryValue: '+27-', CountryCode: 'ZA  -  South Africa' },
               { CountryValue: '+358-', CountryCode: 'AX  -  Aland Islands' },
               { CountryValue: '+355-', CountryCode: 'AL  -  Albania' },
               { CountryValue: '+213-', CountryCode: 'DZ  -  Algeria' },
               { CountryValue: '+1684-', CountryCode: 'AS  -  American Samoa' },
               { CountryValue: '+376-', CountryCode: 'AD  -  Andorra' },
               { CountryValue: '+244-', CountryCode: 'AO  -  Angola' },
               { CountryValue: '+1264-', CountryCode: 'AI  -  Anguilla' },
               { CountryValue: '+672-', CountryCode: 'AQ  -  Antarctica' },
               { CountryValue: '+1268-', CountryCode: 'AG  -  Antigua and Barbuda' },
               { CountryValue: '+54-', CountryCode: 'AR  -  Argentina' },
               { CountryValue: '+374-', CountryCode: 'AM  -  Armenia' },
               { CountryValue: '+297-', CountryCode: 'AW  -  Aruba' },
               { CountryValue: '+43-', CountryCode: 'AT  -  Austria' },
               { CountryValue: '+994-', CountryCode: 'AZ  -  Azerbaijan' },
               { CountryValue: '+1242-', CountryCode: 'BS  -  Bahamas' },
               { CountryValue: '+973-', CountryCode: 'BH  -  Bahrain' },
               { CountryValue: '+880-', CountryCode: 'BD  -  Bangladesh' },
               { CountryValue: '+1246-', CountryCode: 'BB  -  Barbados' },
               { CountryValue: '+32-', CountryCode: 'BE  -  Belgium' },
               { CountryValue: '+501-', CountryCode: 'BZ  -  Belize' },
               { CountryValue: '+229-', CountryCode: 'BJ  -  Benin' },
               { CountryValue: '+1441-', CountryCode: 'BM  -  Bermuda' },
               { CountryValue: '+975-', CountryCode: 'BT  -  Bhutan' },
               { CountryValue: '+591-', CountryCode: 'BO  -  Bolivia' },
               { CountryValue: '+387-', CountryCode: 'BA  -  Bosnia and Herzegovina' },
               { CountryValue: '+267-', CountryCode: 'BW  -  Botswana' },
               { CountryValue: '+47-', CountryCode: 'BV  -  Bouvet Island' },
               { CountryValue: '+55-', CountryCode: 'BR  -  Brazil' },
               { CountryValue: '+246-', CountryCode: 'IO  -  British Indian Ocean Territory' },
               { CountryValue: '+673-', CountryCode: 'BN  -  Brunei Darussalam' },
               { CountryValue: '+359-', CountryCode: 'BG  -  Bulgaria' },
               { CountryValue: '+226-', CountryCode: 'BF  -  Burkina Faso' },
               { CountryValue: '+257-', CountryCode: 'BI  -  Burundi' },
               { CountryValue: '+855-', CountryCode: 'KH  -  Cambodia' },
               { CountryValue: '+237-', CountryCode: 'CM  -  Cameroon' },
               { CountryValue: '+238-', CountryCode: 'CV  -  Cape Verde' },
               { CountryValue: '+599-', CountryCode: 'BQ  -  Caribbean Netherlands ' },
               { CountryValue: '+1345-', CountryCode: 'KY  -  Cayman Islands' },
               { CountryValue: '+236-', CountryCode: 'CF  -  Central African Republic' },
               { CountryValue: '+235-', CountryCode: 'TD  -  Chad' },
               { CountryValue: '+56-', CountryCode: 'CL  -  Chile' },
               { CountryValue: '+86-', CountryCode: 'CN  -  China' },
               { CountryValue: '+61-', CountryCode: 'CX  -  Christmas Island' },
               { CountryValue: '+61-', CountryCode: 'CC  -  Cocos (Keeling) Islands' },
               { CountryValue: '+57-', CountryCode: 'CO  -  Colombia' },
               { CountryValue: '+269-', CountryCode: 'KM  -  Comoros' },
               { CountryValue: '+242-', CountryCode: 'CG  -  Congo' },
               { CountryValue: '+243-', CountryCode: 'CD  -  Congo, Democratic Republic of' },
               { CountryValue: '+682-', CountryCode: 'CK  -  Cook Islands' },
               { CountryValue: '+506-', CountryCode: 'CR  -  Costa Rica' },
               { CountryValue: '+225-', CountryCode: 'CI  -  Cote dIvoire' },
               { CountryValue: '+385-', CountryCode: 'HR  -  Croatia' },
               { CountryValue: '+599-', CountryCode: 'CW  -  Curacao' },
               { CountryValue: '+357-', CountryCode: 'CY  -  Cyprus' },
               { CountryValue: '+420-', CountryCode: 'CZ  -  Czech Republic' },
               { CountryValue: '+45-', CountryCode: 'DK  -  Denmark' },
               { CountryValue: '+253-', CountryCode: 'DJ  -  Djibouti' },
               { CountryValue: '+1767-', CountryCode: 'DM  -  Dominica' },
               { CountryValue: '+1809-', CountryCode: 'DO  -  Dominican Republic' },
               { CountryValue: '+593-', CountryCode: 'EC  -  Ecuador' },
               { CountryValue: '+20-', CountryCode: 'EG  -  Egypt' },
               { CountryValue: '+503-', CountryCode: 'SV  -  El Salvador' },
               { CountryValue: '+240-', CountryCode: 'GQ  -  Equatorial Guinea' },
               { CountryValue: '+291-', CountryCode: 'ER  -  Eritrea' },
               { CountryValue: '+372-', CountryCode: 'EE  -  Estonia' },
               { CountryValue: '+251-', CountryCode: 'ET  -  Ethiopia' },
               { CountryValue: '+500-', CountryCode: 'FK  -  Falkland Islands' },
               { CountryValue: '+298-', CountryCode: 'FO  -  Faroe Islands' },
               { CountryValue: '+679-', CountryCode: 'FJ  -  Fiji' },
               { CountryValue: '+358-', CountryCode: 'FI  -  Finland' },
               { CountryValue: '+33-', CountryCode: 'FR  -  France' },
               { CountryValue: '+594-', CountryCode: 'GF  -  French Guiana' },
               { CountryValue: '+689-', CountryCode: 'PF  -  French Polynesia' },
               { CountryValue: '+262-', CountryCode: 'TF  -  French Southern Territories' },
               { CountryValue: '+241-', CountryCode: 'GA  -  Gabon' },
               { CountryValue: '+220-', CountryCode: 'GM  -  Gambia' },
               { CountryValue: '+995-', CountryCode: 'GE  -  Georgia' },
               { CountryValue: '+49-', CountryCode: 'DE  -  Germany' },
               { CountryValue: '+233-', CountryCode: 'GH  -  Ghana' },
               { CountryValue: '+350-', CountryCode: 'GI  -  Gibraltar' },
               { CountryValue: '+30-', CountryCode: 'GR  -  Greece' },
               { CountryValue: '+299-', CountryCode: 'GL  -  Greenland' },
               { CountryValue: '+1473-', CountryCode: 'GD  -  Grenada' },
               { CountryValue: '+590-', CountryCode: 'GP  -  Guadeloupe' },
               { CountryValue: '+1671-', CountryCode: 'GU  -  Guam' },
               { CountryValue: '+502-', CountryCode: 'GT  -  Guatemala' },
               { CountryValue: '+44-', CountryCode: 'GG  -  Guernsey' },
               { CountryValue: '+224-', CountryCode: 'GN  -  Guinea' },
               { CountryValue: '+245-', CountryCode: 'GW  -  Guinea-Bissau' },
               { CountryValue: '+592-', CountryCode: 'GY  -  Guyana' },
               { CountryValue: '+509-', CountryCode: 'HT  -  Haiti' },
               { CountryValue: '+-', CountryCode: 'HM  -  Heard and McDonald Islands' },
               { CountryValue: '+504-', CountryCode: 'HN  -  Honduras' },
               { CountryValue: '+852-', CountryCode: 'HK  -  Hong Kong' },
               { CountryValue: '+36-', CountryCode: 'HU  -  Hungary' },
               { CountryValue: '+354-', CountryCode: 'IS  -  Iceland' },
               { CountryValue: '+62-', CountryCode: 'ID  -  Indonesia' },
               { CountryValue: '+964-', CountryCode: 'IQ  -  Iraq' },
               { CountryValue: '+353-', CountryCode: 'IE  -  Ireland' },
               { CountryValue: '+44-', CountryCode: 'IM  -  Isle of Man' },
               { CountryValue: '+972-', CountryCode: 'IL  -  Israel' },
               { CountryValue: '+39-', CountryCode: 'IT  -  Italy' },
               { CountryValue: '+1876-', CountryCode: 'JM  -  Jamaica' },
               { CountryValue: '+81-', CountryCode: 'JP  -  Japan' },
               { CountryValue: '+44-', CountryCode: 'JE  -  Jersey' },
               { CountryValue: '+962-', CountryCode: 'JO  -  Jordan' },
               { CountryValue: '+7-', CountryCode: 'KZ  -  Kazakhstan' },
               { CountryValue: '+254-', CountryCode: 'KE  -  Kenya' },
               { CountryValue: '+686-', CountryCode: 'KI  -  Kiribati' },
               { CountryValue: '+965-', CountryCode: 'KW  -  Kuwait' },
               { CountryValue: '+996-', CountryCode: 'KG  -  Kyrgyzstan' },
               { CountryValue: '+856-', CountryCode: 'LA  -  Lao Peoples Democratic Republic' },
               { CountryValue: '+371-', CountryCode: 'LV  -  Latvia' },
               { CountryValue: '+961-', CountryCode: 'LB  -  Lebanon' },
               { CountryValue: '+266-', CountryCode: 'LS  -  Lesotho' },
               { CountryValue: '+231-', CountryCode: 'LR  -  Liberia' },
               { CountryValue: '+218-', CountryCode: 'LY  -  Libya' },
               { CountryValue: '+423-', CountryCode: 'LI  -  Liechtenstein' },
               { CountryValue: '+370-', CountryCode: 'LT  -  Lithuania' },
               { CountryValue: '+352-', CountryCode: 'LU  -  Luxembourg' },
               { CountryValue: '+853-', CountryCode: 'MO  -  Macau' },
               { CountryValue: '+389-', CountryCode: 'MK  -  Macedonia' },
               { CountryValue: '+261-', CountryCode: 'MG  -  Madagascar' },
               { CountryValue: '+265-', CountryCode: 'MW  -  Malawi' },
               { CountryValue: '+60-', CountryCode: 'MY  -  Malaysia' },
               { CountryValue: '+960-', CountryCode: 'MV  -  Maldives' },
               { CountryValue: '+223-', CountryCode: 'ML  -  Mali' },
               { CountryValue: '+356-', CountryCode: 'MT  -  Malta' },
               { CountryValue: '+692-', CountryCode: 'MH  -  Marshall Islands' },
               { CountryValue: '+596-', CountryCode: 'MQ  -  Martinique' },
               { CountryValue: '+222-', CountryCode: 'MR  -  Mauritania' },
               { CountryValue: '+230-', CountryCode: 'MU  -  Mauritius' },
               { CountryValue: '+262-', CountryCode: 'YT  -  Mayotte' },
               { CountryValue: '+52-', CountryCode: 'MX  -  Mexico' },
               { CountryValue: '+691-', CountryCode: 'FM  -  Micronesia, Federated States of' },
               { CountryValue: '+373-', CountryCode: 'MD  -  Moldova' },
               { CountryValue: '+377-', CountryCode: 'MC  -  Monaco' },
               { CountryValue: '+976-', CountryCode: 'MN  -  Mongolia' },
               { CountryValue: '+382-', CountryCode: 'ME  -  Montenegro' },
               { CountryValue: '+1664-', CountryCode: 'MS  -  Montserrat' },
               { CountryValue: '+212-', CountryCode: 'MA  -  Morocco' },
               { CountryValue: '+258-', CountryCode: 'MZ  -  Mozambique' },
               { CountryValue: '+264-', CountryCode: 'NA  -  Namibia' },
               { CountryValue: '+674-', CountryCode: 'NR  -  Nauru' },
               { CountryValue: '+977-', CountryCode: 'NP  -  Nepal' },
               { CountryValue: '+687-', CountryCode: 'NC  -  New Caledonia' },
               { CountryValue: '+64-', CountryCode: 'NZ  -  New Zealand' },
               { CountryValue: '+505-', CountryCode: 'NI  -  Nicaragua' },
               { CountryValue: '+227-', CountryCode: 'NE  -  Niger' },
               { CountryValue: '+234-', CountryCode: 'NG  -  Nigeria' },
               { CountryValue: '+683-', CountryCode: 'NU  -  Niue' },
               { CountryValue: '+672-', CountryCode: 'NF  -  Norfolk Island' },
               { CountryValue: '+1670-', CountryCode: 'MP  -  Northern Mariana Islands' },
               { CountryValue: '+47-', CountryCode: 'NO  -  Norway' },
               { CountryValue: '+968-', CountryCode: 'OM  -  Oman' },
               { CountryValue: '+92-', CountryCode: 'PK  -  Pakistan' },
               { CountryValue: '+680-', CountryCode: 'PW  -  Palau' },
               { CountryValue: '+970-', CountryCode: 'PS  -  Palestinian Territory, Occupied' },
               { CountryValue: '+507-', CountryCode: 'PA  -  Panama' },
               { CountryValue: '+675-', CountryCode: 'PG  -  Papua New Guinea' },
               { CountryValue: '+595-', CountryCode: 'PY  -  Paraguay' },
               { CountryValue: '+51-', CountryCode: 'PE  -  Peru' },
               { CountryValue: '+63-', CountryCode: 'PH  -  Philippines' },
               { CountryValue: '+870-', CountryCode: 'PN  -  Pitcairn' },
               { CountryValue: '+48-', CountryCode: 'PL  -  Poland' },
               { CountryValue: '+351-', CountryCode: 'PT  -  Portugal' },
               { CountryValue: '+1-', CountryCode: 'PR  -  Puerto Rico' },
               { CountryValue: '+974-', CountryCode: 'QA  -  Qatar' },
               { CountryValue: '+262-', CountryCode: 'RE  -  Reunion' },
               { CountryValue: '+40-', CountryCode: 'RO  -  Romania' },
               { CountryValue: '+7-', CountryCode: 'RU  -  Russian Federation' },
               { CountryValue: '+250-', CountryCode: 'RW  -  Rwanda' },
               { CountryValue: '+590-', CountryCode: 'BL  -  Saint Barthelemy' },
               { CountryValue: '+290-', CountryCode: 'SH  -  Saint Helena' },
               { CountryValue: '+1869-', CountryCode: 'KN  -  Saint Kitts and Nevis' },
               { CountryValue: '+1758-', CountryCode: 'LC  -  Saint Lucia' },
               { CountryValue: '+1784-', CountryCode: 'VC  -  Saint Vincent and the Grenadines' },
               { CountryValue: '+1599-', CountryCode: 'MF  -  Saint-Martin (France)' },
               { CountryValue: '+1721-', CountryCode: 'SX  -  Saint-Martin (Pays-Bas)' },
               { CountryValue: '+685-', CountryCode: 'WS  -  Samoa' },
               { CountryValue: '+378-', CountryCode: 'SM  -  San Marino' },
               { CountryValue: '+239-', CountryCode: 'ST  -  Sao Tome and Principe' },
               { CountryValue: '+221-', CountryCode: 'SN  -  Senegal' },
               { CountryValue: '+381-', CountryCode: 'RS  -  Serbia' },
               { CountryValue: '+248-', CountryCode: 'SC  -  Seychelles' },
               { CountryValue: '+232-', CountryCode: 'SL  -  Sierra Leone' },
               { CountryValue: '+421-', CountryCode: 'SK  -  Slovakia (Slovak Republic)' },
               { CountryValue: '+386-', CountryCode: 'SI  -  Slovenia' },
               { CountryValue: '+677-', CountryCode: 'SB  -  Solomon Islands' },
               { CountryValue: '+252-', CountryCode: 'SO  -  Somalia' },
               { CountryValue: '+500-', CountryCode: 'GS  -  South Georgia and the South Sandwich Islands' },
               { CountryValue: '+82-', CountryCode: 'KR  -  South Korea' },
               { CountryValue: '+211-', CountryCode: 'SS  -  South Sudan' },
               { CountryValue: '+34-', CountryCode: 'ES  -  Spain' },
               { CountryValue: '+94-', CountryCode: 'LK  -  Sri Lanka' },
               { CountryValue: '+508-', CountryCode: 'PM  -  St. Pierre and Miquelon' },
               { CountryValue: '+597-', CountryCode: 'SR  -  Suriname' },
               { CountryValue: '+47-', CountryCode: 'SJ  -  Svalbard and Jan Mayen Islands' },
               { CountryValue: '+268-', CountryCode: 'SZ  -  Swaziland' },
               { CountryValue: '+46-', CountryCode: 'SE  -  Sweden' },
               { CountryValue: '+886-', CountryCode: 'TW  -  Taiwan' },
               { CountryValue: '+992-', CountryCode: 'TJ  -  Tajikistan' },
               { CountryValue: '+255-', CountryCode: 'TZ  -  Tanzania' },
               { CountryValue: '+66-', CountryCode: 'TH  -  Thailand' },
               { CountryValue: '+31-', CountryCode: 'NL  -  The Netherlands' },
               { CountryValue: '+670-', CountryCode: 'TL  -  Timor-Leste' },
               { CountryValue: '+228-', CountryCode: 'TG  -  Togo' },
               { CountryValue: '+690-', CountryCode: 'TK  -  Tokelau' },
               { CountryValue: '+676-', CountryCode: 'TO  -  Tonga' },
               { CountryValue: '+1868-', CountryCode: 'TT  -  Trinidad and Tobago' },
               { CountryValue: '+216-', CountryCode: 'TN  -  Tunisia' },
               { CountryValue: '+90-', CountryCode: 'TR  -  Turkey' },
               { CountryValue: '+993-', CountryCode: 'TM  -  Turkmenistan' },
               { CountryValue: '+1649-', CountryCode: 'TC  -  Turks and Caicos Islands' },
               { CountryValue: '+688-', CountryCode: 'TV  -  Tuvalu' },
               { CountryValue: '+256-', CountryCode: 'UG  -  Uganda' },
               { CountryValue: '+380-', CountryCode: 'UA  -  Ukraine' },
               { CountryValue: '+699-', CountryCode: 'UM  -  United States Minor Outlying Islands' },
               { CountryValue: '+598-', CountryCode: 'UY  -  Uruguay' },
               { CountryValue: '+998-', CountryCode: 'UZ  -  Uzbekistan' },
               { CountryValue: '+678-', CountryCode: 'VU  -  Vanuatu' },
               { CountryValue: '+39-', CountryCode: 'VA  -  Vatican' },
               { CountryValue: '+58-', CountryCode: 'VE  -  Venezuela' },
               { CountryValue: '+84-', CountryCode: 'VN  -  Vietnam' },
               { CountryValue: '+1284-', CountryCode: 'VG  -  Virgin Islands (British)' },
               { CountryValue: '+1340-', CountryCode: 'VI  -  Virgin Islands (U.S.)' },
               { CountryValue: '+681-', CountryCode: 'WF  -  Wallis and Futuna Islands' },
               { CountryValue: '+212-', CountryCode: 'EH  -  Western Sahara' },
               { CountryValue: '+967-', CountryCode: 'YE  -  Yemen' },
               { CountryValue: '+260-', CountryCode: 'ZM  -  Zambia' }
            ],
        };
    }]);