<?php
/*
Plugin Name: Cheama Curier
Plugin URI: https://www.example.com/
Description: Cheama Curier - Custom Plugin for Dexter IT
Version: 1.0
Author: Ionut Hurmuz
Author URI: https://www.example.com/
*/

function load_custom_stylesheet() {
  wp_enqueue_style( 'custom-style', plugin_dir_url( __FILE__ ) . 'new.css' );
}
add_action( 'wp_enqueue_scripts', 'load_custom_stylesheet' );


add_action( 'wpcf7_before_send_mail', 'cf7_data_send_func' );

function cf7_data_send_func( $contact_form ){
  // Get the form data from Contact Form 7
  $submission = WPCF7_Submission::get_instance();
  $form_data = $submission->get_posted_data();
  // Get the form id
  $form_name = $contact_form->name();
  
  // Check if the form id is equal to the id of your form
  if ( $form_name == 'fan_courier' ) {
      // Prepare the data to be sent
    $data = array(
      'expeditor_nume' => $form_data['expeditor_nume'],
      'expeditor_persoana_contact' => $form_data['expeditor_nume'],
      'expeditor_telefon' => $form_data['expeditor_telefon'],
      'expeditor_fax' => '',     
      'expeditor_email' => $form_data['expeditor_email'],
      'expeditor_judet' => $form_data['expeditor_judet'],
      'expeditor_localitatea' => $form_data['expeditor_localitatea'],
      'expeditor_strada' => $form_data['expeditor_strada'],
      'expeditor_nr' => '',
      'expeditor_cod_postal' => $form_data['expeditor_cod_postal'],
      'expeditor_bloc' => '',
      'expeditor_scara' => '',
      'expeditor_etaj' => '',
      'expeditor_apartament' => '',
      'destinatar_nume' => 'Dexter IT',
      'destinatar_persoana_contact' => 'Vizitiu Bogdan Andrei',
      'destinatar_telefon' => '0745705010', 
      'destinatar_fax' => '', 
      'destinatar_email' => '', 
      'destinatar_judet' => 'Botosani', 
      'destinatar_localitatea' => 'Botosani', 
      'destinatar_strada' => 'Bld. Mihai Eminescu nr.2, Botosani Shoping Center', 
      'destinatar_nr' => '', 
      'destinatar_cod postal' => '710014', 
      'destinatar_bloc' => '', 
      'destinatar_scara' => '', 
      'destinatar_etaj' => '', 
      'destinatar_apartament' => '', 
      'tip_serviciu' => 'Standard', 
      'banca' => '', 
      'IBAN' => '', 
      'nr_plicuri' => '', 
      'nr_colete' => '1', 
      'greutate' => '1', 
      'plata_expeditie' => 'destinatar', 
      'ramburs' => '', 
      'plata_ramburs_la' => '', 
      'valoare_declarata' => '', 
      'observatii' => '', 
      'continut' => $form_data['continut'],
      'inaltime_pachet' => '', 
      'latime_pachet' => '', 
      'lungime_pachet' => '', 
      'restituire' => '', 
      'optiuni' => '', 
      'expeditor_dropoff' => ''
      
      // ... add the rest of the form fields here
    );
    $fisier_top=array('Tip serviciu','Banca','IBAN','Nr. Plicuri','Nr. Colete','Greutate','Plata expeditie','Ramburs(bani)','Plata ramburs la','Valoare declarata','Persoana contact expeditor','Observatii','Continut','Nume destinatar','Persoana contact','Telefon','Fax','Email','Judet','Localitatea','Strada','Nr','Cod postal','Bloc','Scara','Etaj','Apartament','Inaltime pachet','Latime pachet','Lungime pachet','Restituire','Centru Cost','Optiuni','Packing','Date personale');
    // Create a temporary file for the CSV data
    $file = fopen('fisier.csv', 'w');
    // Write the data to the CSV file
    fputcsv($file, $fisier_top);
    fputcsv($file, $data);
    
    // Close the file
    fclose($file);
    
    // URL of the API endpoint
    $url = 'https://www.selfawb.ro/all/import_awb_integrat.php';
    
    // Initialize a new curl session
    $ch = curl_init();
    
    // Set the URL and request method
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_POST, true);

    $cfile = new CURLFile('fisier.csv', 'text/csv', 'fisier.csv');

    // Date logare client Fan
    $final = array(
      'username' => 'clienttest@fancourier.ro', 
      'client_id' => '323245',     
      'user_pass' => 'testareFAN',
      'fisier' => $cfile
    );
    
    curl_setopt($ch, CURLOPT_POSTFIELDS, $final);
    // Follow redirects
    curl_setopt($ch, CURLOPT_FOLLOWLOCATION, true);

    // Return the response as a string
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    // Execute the curl request
    $response = curl_exec($ch);
    // Check for errors
    $afisare = 'Nimic de afisat';
    if (curl_errno($ch)) {
      // An error occurred, handle it
      $error = curl_error($ch);
      // ...
    } else {
      // No errors, process the response
      $status_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);

      if ($status_code >= 200 && $status_code < 300) {
        // The request was successful, handle the response
        $data = json_decode($response, true);
        if ($data !== null) {
            $rezultat = json_encode($data, JSON_PRETTY_PRINT);
          // The response is in JSON format
          // ... process the JSON data
        } else {
          // Procesare AWB spre afisare + mail 
            $pieces = explode(",", $response);
            $succes = $pieces[1];
            $awb = $pieces[2];
            if ($succes){
                $afisare = "Numarul dvs AWB este: " . $awb;
                update_option('fan_mesaj', $afisare);
                //error_log(print_r($afisare, true));
                
                // Trimite mail la Server
                $to1 = "contact@rustgates.com";
                $subject1 = "Comanda FanCourier Noua! AWB: ". $awb;
                $message1 = "S-a inregistrat o noua comanda de curier pentru " . $form_data['expeditor_nume'] . " cu adresa " . $form_data['expeditor_judet'] . " , " . $form_data['expeditor_localitatea'] . " , " . $form_data['expeditor_strada'] . " . Numar de telefon client: " . $form_data['expeditor_telefon'] ;
                $headers = array('Content-Type: text/html; charset=UTF-8');
                wp_mail( $to1, $subject1, $message1, $headers );

                $email = $form_data['expeditor_email'];
                if ($email != ''){
                $to2 = $email;
                $subject2 = "DexterIT -> Multumim pentru comanda dumneavoastra";
                $message2 = "S-a inregistrat cu succes comanda dvs de curier. Un membru FanCourier va prelua produsul de la dvs in curand. Puteti verifica situatia comenzii urmarind AWB-ul: " . $awb;
                wp_mail( $to2, $subject2, $message2, $headers );
               }
                //

            }else{
              $afisare = "Eroare: " . $awb;
              update_option('fan_mesaj', $afisare);
            }        

          // The response is not in JSON format
          // ... process the response as needed
          
        }
      } else {
        // The request was not successful, handle the error
        // ...
      } 
    }
  // Close the curl session
  
  curl_close($ch);
  }
}
add_filter('wpcf7_display_message', 'fan_courier_mesaj', 10, 2);
function fan_courier_mesaj($message, $status) {
  $submission = WPCF7_Submission::get_instance();
  if ($submission) {
    $form = $submission->get_contact_form();
    if ('fan_courier' == $form->name() && 'mail_sent_ok' == $status) {
      $message = get_option('fan_mesaj');
    }
  }
  return $message;
}

?>