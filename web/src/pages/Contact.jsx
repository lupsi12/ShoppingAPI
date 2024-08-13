import Layout from "../components/layout/Layout";
import '../styles/Contact.css';
const Contact = () => {
    return (
        <Layout>
            <div className="contact-container">
                <div className="h2-container">
                Bize Ulaşın
                </div>
                <div className="main-container">
                <p> <strong>Adres: </strong>Levent Mahallesi Meltem Sokak İş Bankası Kuleleri No:10 İç Kapı No:7 Beşiktaş/İstanbul</p> 
                <p> <strong>Telefon: </strong>İş Bankası Maximiles ile yapılan işlemler için <strong><a href="tel:08502903371" target="_blank" rel="noopener">0 850 290 33 71</a></strong> numaralarından bize ulaşabilirsiniz.</p>
                </div>
            </div>
        </Layout>
    );
}
export default Contact;