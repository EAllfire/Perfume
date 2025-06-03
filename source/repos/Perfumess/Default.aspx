<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Perfumess.Default" %><asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body, html {
            height: 100%;
            margin: 0;
            padding: 0;
            background: #18181b;
            color: #f3f3f3;
            font-family: 'Segoe UI', Arial, sans-serif;
        }
        .inicio-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 70vh;
            padding: 40px 0;
        }
        .inicio-card {
            background: linear-gradient(135deg, #23272f 80%, #343541 100%);
            box-shadow: 0 4px 32px rgba(0,0,0,0.32);
            border-radius: 22px;
            padding: 48px 40px 40px 40px;
            max-width: 480px;
            text-align: center;
            margin-bottom: 40px;
            position: relative;
            overflow: hidden;
            border: 1.5px solid #282c34;
        }
        .inicio-card:before {
            content: "";
            position: absolute;
            top: -60px; left: -60px;
            width: 200px; height: 200px;
            background: radial-gradient(circle at 30% 30%, #8b5cf6 0%, #23272f 80%);
            opacity: 0.18;
            z-index: 0;
        }
        .inicio-card h2 {
            font-size: 2.5rem;
            margin-bottom: 18px;
            color: #ffd700;
            font-weight: 700;
            letter-spacing: 1.5px;
            z-index: 1;
            position: relative;
        }
        .inicio-card p {
            font-size: 1.2rem;
            color: #b3b7c3;
            margin-bottom: 24px;
            z-index: 1;
            position: relative;
        }
        .inicio-card .btn-empezar {
            display: inline-block;
            background: linear-gradient(90deg, #8b5cf6, #06b6d4);
            color: #fff;
            padding: 14px 40px;
            font-size: 1.1rem;
            border: none;
            border-radius: 50px;
            font-weight: 600;
            cursor: pointer;
            transition: background 0.3s, transform 0.2s;
            margin-top: 10px;
            box-shadow: 0 2px 8px rgba(66, 58, 99, 0.23);
            z-index: 1;
            position: relative;
        }
        .inicio-card .btn-empezar:hover {
            background: linear-gradient(90deg, #06b6d4, #8b5cf6);
            transform: translateY(-2px) scale(1.04);
        }
        .inicio-destacados {
            margin-top: 40px;
            display: flex;
            gap: 30px;
            justify-content: center;
            flex-wrap: wrap;
            z-index: 1;
            position: relative;
        }
        .card-destacado {
            background: #23272f;
            border-radius: 16px;
            padding: 28px 24px;
            box-shadow: 0 2px 12px rgba(0,0,0,0.12);
            max-width: 220px;
            text-align: center;
            border: 1px solid #2c2f36;
            transition: transform 0.17s;
        }
        .card-destacado:hover {
            transform: translateY(-4px) scale(1.03);
            border-color: #8b5cf6;
        }
        .card-destacado img {
            width: 60px; height: 60px;
            margin-bottom: 15px;
            border-radius: 12px;
            object-fit: cover;
            border: 2px solid #343541;
        }
        .card-destacado h4 {
            color: #06b6d4;
            margin-bottom: 7px;
            font-size: 1.13rem;
            font-weight: 600;
        }
        .card-destacado p {
            color: #b3b7c3;
            font-size: 1rem;
        }
        @media (max-width:600px) {
            .inicio-card {max-width:98%; padding:25px 6px;}
            .inicio-destacados {flex-direction:column; gap:16px;}
            .card-destacado {max-width:99%;}
        }
    </style>
    <div class="inicio-container">
        <div class="inicio-card">
            <h2>Bienvenido a <span style="color:#8b5cf6;">PerfumeStore</span></h2>
            <p>Tu destino para las mejores fragancias de diseñador.<br>
            Explora, descubre y déjate sorprender por aromas únicos.<br>
            ¡Encuentra tu esencia ideal con nosotros!</p>
            <a class="btn-empezar" href="Catalogo.aspx">Explorar catálogo</a>
        </div>
        <div class="inicio-destacados">
            <div class="card-destacado">
                <img src="Imagenes/destacados1.jpg" alt="Perfume destacado 1" />
                <h4>Aromas de lujo</h4>
                <p>Fragancias exclusivas de marcas premium para todos los gustos.</p>
            </div>
            <div class="card-destacado">
                <img src="Imagenes/destacados2.jpg" alt="Perfume destacado 2" />
                <h4>Ofertas semanales</h4>
                <p>Promociones y descuentos especiales, ¡no te los pierdas!</p>
            </div>
            <div class="card-destacado">
                <img src="Imagenes/destacados3.jpg" alt="Perfume destacado 3" />
                <h4>Envío rápido</h4>
                <p>Recibe tus perfumes favoritos en la puerta de tu casa.</p>
            </div>
        </div>
    </div>
</asp:Content>